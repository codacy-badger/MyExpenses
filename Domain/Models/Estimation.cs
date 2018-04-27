﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Estimation")]
    public class Estimation : ModelBase
    {
        [Required]
        [ForeignKey("LabelId")]
        public Label Label { get; set; }

        [Required]
        [Range(0.0f, float.MaxValue)]
        [DataType(DataType.Currency)]
        public float Value { get; set; }
    }
}