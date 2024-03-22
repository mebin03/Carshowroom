using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carshowroom.Brands;
using Carshowroom.Permissions;
using AutoMapper.Internal.Mappers;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;

namespace Carshowroom.Blazor.Pages;

public partial class Brands
{
    private IReadOnlyList<BrandDto> BrandList { get; set; }

    private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
    private int CurrentPage { get; set; }
    private string CurrentSorting { get; set; }
    private int TotalCount { get; set; }

    private bool CanCreateBrand { get; set; }
    private bool CanEditBrand { get; set; }
    private bool CanDeleteBrand { get; set; }

    private CreateBrandDto NewBrand { get; set; }

    private Guid EditingBrandId { get; set; }
    private UpdateBrandDto EditingBrand{ get; set; }

    private Modal CreateBrandModal { get; set; }
    private Modal EditBrandModal { get; set; }

    private Validations CreateValidationsRef;

    private Validations EditValidationsRef;

    public Brands()
    {
        NewBrand = new CreateBrandDto();
        EditingBrand = new UpdateBrandDto();
    }

    protected override async Task OnInitializedAsync()
    {
        await SetPermissionsAsync();
        await GetBrandsAsync();
    }

    private async Task SetPermissionsAsync()
    {
        CanCreateBrand = await AuthorizationService
            .IsGrantedAsync(CarshowroomPermissions.Brands.Create);

        CanEditBrand = await AuthorizationService
            .IsGrantedAsync(CarshowroomPermissions.Brands.Edit);

        CanDeleteBrand = await AuthorizationService
            .IsGrantedAsync(CarshowroomPermissions.Brands.Delete);
    }

    private async Task GetBrandsAsync()
    {
        var result = await BrandAppService.GetListAsync(
            new GetBrandListDto
            {
                MaxResultCount = PageSize,
                SkipCount = CurrentPage * PageSize,
                Sorting = CurrentSorting
            }
        );

        BrandList = result.Items;
        TotalCount = (int)result.TotalCount;
    }

    private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<BrandDto> e)
    {
        CurrentSorting = e.Columns
            .Where(c => c.SortDirection != SortDirection.Default)
            .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
            .JoinAsString(",");
        CurrentPage = e.Page - 1;

        await GetBrandsAsync();

        await InvokeAsync(StateHasChanged);
    }

    private void OpenCreateBrandModal()
    {
        CreateValidationsRef.ClearAll();

        NewBrand = new CreateBrandDto();
        CreateBrandModal.Show();
    }

    private void CloseCreateBrandModal()
    {
        CreateBrandModal.Hide();
    }

    private void OpenEditBrandModal(BrandDto brand)
    {
        EditValidationsRef.ClearAll();

        EditingBrandId = brand.Id;
        EditingBrand = ObjectMapper.Map<BrandDto, UpdateBrandDto>(brand);
        EditBrandModal.Show();
    }

    private async Task DeleteBrandAsync(BrandDto brand)
    {
        var confirmMessage = L["BrandDeletionConfirmationMessage", brand.Name];
        if (!await Message.Confirm(confirmMessage))
        {
            return;
        }

        await BrandAppService.DeleteAsync(brand.Id);
        await GetBrandsAsync();
    }

    private void CloseEditBrandModal()
    {
        EditBrandModal.Hide();
    }

    private async Task CreateBrandAsync()
    {
        if (await CreateValidationsRef.ValidateAll())
        {
            await BrandAppService.CreateAsync(NewBrand);
            await GetBrandsAsync();
            CreateBrandModal.Hide();
        }
    }

    private async Task UpdateBrandAsync()
    {
        if (await EditValidationsRef.ValidateAll())
        {
            await BrandAppService.UpdateAsync(EditingBrandId, EditingBrand);
            await GetBrandsAsync();
            EditBrandModal.Hide();
        }
    }
}
