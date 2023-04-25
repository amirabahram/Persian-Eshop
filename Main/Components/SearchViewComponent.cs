using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.Filtering;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Components
{
    [ViewComponent]
    public class SearchViewComponent:ViewComponent
    {
        private IProductServices _productServices;
        public SearchViewComponent(IProductServices productServices)
        {
            this._productServices = productServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(FilterProductViewModel? model)
        {
            var filterModel = await _productServices.Filter(model);
            return View("Search", filterModel);
        }
    }
}
