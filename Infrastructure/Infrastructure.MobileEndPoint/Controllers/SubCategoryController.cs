using Core.ApplicationServices;
using Core.Entities.Dto;
using Infrastructure.EndPoint.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Infrastructure.MobileEndpoint.Controllers
{
    public class SubCategoryController : SimpleController
    {
        private readonly IAddSubCategory addCategory;
        private readonly IListSubCategory listCategory;
        private readonly IDeleteSubCategory deleteCategory;
        private readonly IEditSubCategory editCategory;
        private readonly IGetByIdSubCategory getByIdCategory;
        private readonly IArrangeSubCategory arrangeSubCategory;
        private readonly IGetSubCategoryByArrange getSubCategoryByArrange;

        public SubCategoryController(
            
           IAddSubCategory addCategory,
           IListSubCategory listCategory,
           IDeleteSubCategory deleteCategory,
           IEditSubCategory editCategory,
           IGetByIdSubCategory getByIdCategory,
           IArrangeSubCategory arrangeSubCategory,
           IGetSubCategoryByArrange getSubCategoryByArrange 
            
            )
        {
            this.addCategory = addCategory;
            this.listCategory = listCategory;
            this.deleteCategory = deleteCategory;
            this.editCategory = editCategory;
            this.getByIdCategory = getByIdCategory;
            this.arrangeSubCategory = arrangeSubCategory;
            this.getSubCategoryByArrange = getSubCategoryByArrange;
        }

        [HttpPost]
        public ActionResult<AddSubCategoryResultDto> Create([FromBody] AddSubCategoryDto dto)
        {
            return addCategory.Execute(dto);
        }


        [HttpGet]
        public ActionResult<ListSubCategoryResultDto> List([FromQuery] ListSubCategoryDto dto)
        {
            return listCategory.Execute(dto);
        }
   
        [HttpGet]
        public ActionResult<GetByIdSubCategoryResultDto> GetById([FromQuery] GetByIdSubCategoryDto dto)
        {
            return getByIdCategory.Execute(dto);
        }
        [HttpPut]
        public ActionResult<EditSubCategoryResultDto> Edit([FromBody] EditSubCategoryDto dto)
        {
            return editCategory.Execute(dto);
        }
        [HttpDelete]
        public ActionResult<DeleteSubCategoryResultDto> Delete([FromQuery] DeleteSubCategoryDto dto)
        {
            return deleteCategory.Execute(dto);
        }
        [HttpPost]
        public ActionResult<ArrangeSubCategoryResultDto> Arrange([FromBody] ArrangeSubCategoryDto dto)
        {
            return arrangeSubCategory.Execute(dto);
        }


        [HttpGet]
        public ActionResult<GetSubCategoryByArrangeResultDto> GetByArrange([FromQuery] GetSubCategoryByArrangeDto dto)
        {
            return getSubCategoryByArrange.Execute(dto);
        }





    }
}
