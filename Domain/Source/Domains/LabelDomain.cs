/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Domains
{
    using MyExpenses.Domain.Interfaces;

    public class LabelDomain : DomainBase
    {
        public string Name { get; set; }

        public override void Copy(IBaseId baseObj)
        {
            if (baseObj is LabelDomain obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
