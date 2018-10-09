/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Domains
{
    using MyExpenses.Domain.Interfaces;

    public class GroupDomain : DomainBase
    {
        public string Name { get; set; }

        public override void Copy(IBaseId baseObj)
        {
            if (baseObj is GroupDomain obj)
            {
                AutoMapper.Mapper.Map(this, obj);
            }
        }
    }
}
