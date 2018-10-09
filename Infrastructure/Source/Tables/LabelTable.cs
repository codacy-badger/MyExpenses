/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tables
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Label")]
    public class LabelTable : TableBase
    {
        public override void Copy(ITable baseObj)
        {
            if (baseObj is LabelTable obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
