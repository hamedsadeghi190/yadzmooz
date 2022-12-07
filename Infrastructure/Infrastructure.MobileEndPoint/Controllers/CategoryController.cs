using Core.ApplicationServices;
using Core.Entities.Dto;
using Infrastructure.EndPoint.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.MobileEndpoint.Controllers
{
    public class CategoryController : SimpleController
    {
        private readonly IAddCategory addCategory;
        private readonly IListCategory listCategory;
        private readonly IDeleteCategory deleteCategory;
        private readonly IEditCategory editCategory;
        private readonly IGetByIdCategory getByIdCategory;

        public CategoryController(
            
           IAddCategory addCategory,
           IListCategory listCategory,
           IDeleteCategory deleteCategory,
           IEditCategory editCategory,
           IGetByIdCategory getByIdCategory
            
            )
        {
            this.addCategory = addCategory;
            this.listCategory = listCategory;
            this.deleteCategory = deleteCategory;
            this.editCategory = editCategory;
            this.getByIdCategory = getByIdCategory;
        }

        [HttpPost]
        public ActionResult<AddCategoryResultDto> Create([FromBody] AddCategoryDto dto)
        {
            return addCategory.Execute(dto);
        }


        [HttpGet]
        public ActionResult<ListCategoryResultDto> List([FromQuery] ListCategoryDto dto)
        {
            return listCategory.Execute(dto);
        }

        [HttpGet]
        public ActionResult<ListCategoryMobileResultDto> MobileList([FromQuery] ListCategoryDto dto)
        {
            return listCategory.MobileExecute(dto);
        }

        [HttpGet]
        public ActionResult<GetByIdCategoryResultDto> GetById([FromQuery] GetByIdCategoryDto dto)
        {
            return getByIdCategory.Execute(dto);
        }

        [HttpPut]
        public ActionResult<EditCategoryResultDto> Edit([FromBody] EditCategoryDto dto)
        {
            return editCategory.Execute(dto);
        }
        [HttpDelete]
        public ActionResult<DeleteCategoryResultDto> Delete([FromQuery] DeleteCategoryDto dto)
        {
            return deleteCategory.Execute(dto);
        }




    }
}
