namespace lfmachadodasilva.MyExpenses.WebApplication.Models.ViewModels
{
    public class LabelsViewModel : ViewModelBase<LabelViewModel>
    {
        public GroupViewModel Group { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }
    }

    public class LabelViewModel : ViewModelBase
    {
        public string Name { get; set; }
    }
}
