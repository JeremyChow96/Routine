using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Routine.API.Models
{
    public class CompanyAddDto
    {
        [Display(Name = "公司名")]
        [Required(ErrorMessage = "{0}属性必须填写")]
        //占位符 0 -本身 1 从左往右 第1个参数
        [MaxLength(100,ErrorMessage = "{0}的最大长度为{1}")]
        public string Name { get; set; }
        [Display(Name = "简介")]
    
        [StringLength(500, MinimumLength = 10,ErrorMessage = "{0}的范围从{1}-{2}")]
        public string Introduction { get; set; }

        public ICollection<EmployeeAddDto> Employees { get; set; } = new List<EmployeeAddDto>();
    }
}