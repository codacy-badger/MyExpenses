/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Tables
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Payment")]
    public class PaymentTable : TableBase
    {
        public override void Copy(ITable baseObj)
        {
            if (baseObj is PaymentTable obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
