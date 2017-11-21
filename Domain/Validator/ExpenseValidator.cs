﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Domain.Validator
{
    using System;

    using MyExpenses.Domain.Interfaces;
    using MyExpenses.Domain.Models;
    using MyExpenses.Domain.Properties;
    using MyExpenses.Util.Results;

    public class ExpenseValidator : IValidator
    {
        public MyResults Validate(IDomain obj)
        {
            if (obj == null)
            {
                throw new ArgumentException(string.Format(Resources.Validation_InvalidObject, Resources.Expense));
            }

            Expense expense = obj as Expense;

            if (expense == null)
            {
                throw new ArgumentException(string.Format(Resources.Validation_InvalidTypeObject, Resources.Expense));
            }

            if (obj.Id < 0)
            {
                return new MyResults(MyResultsStatus.Error, MyResultsAction.Validating, string.Format(Resources.Validate_Id_Invalid, Resources.Expense));
            }

            if (string.IsNullOrEmpty(expense.Name))
            {
                return new MyResults(MyResultsStatus.Error, MyResultsAction.Validating, string.Format(Resources.Validate_Field_Invalid, Resources.Expense, Resources.Name));
            }

            if (expense.Name.Length > 128)
            {
                return new MyResults(MyResultsStatus.Error, MyResultsAction.Validating, string.Format(Resources.Validate_Field_Invalid, Resources.Expense, Resources.Name));
            }

            if (expense.Value < 0)
            {
                return new MyResults(MyResultsStatus.Error, MyResultsAction.Validating, string.Format(Resources.Validate_Field_Invalid, Resources.Expense, Resources.Value));
            }

            return new MyResults(MyResultsStatus.Ok, MyResultsAction.Validating);
        }
    }
}
