# MyExpenses

Project to control personal expenses

### Additional Information
  - dotnet core version 2.1
  - entity framework version 2.1.1
  - sql server (future change to postgresql)

### Steps to run:
  - prepare database: 
    - core context: `dotnet ef database update --project src/lfmachadodasilva.MyExpenses.WebApplication --contex
t MyExpensesContext`
    - identity context: `dotnet ef database update --project src/lfmachadodasilva.MyExpenses.WebApplication --contex
t ApplicationDbContext`
  - build: `dotnet build`
  - run: `dotnet run --project src/lfmachadodasilva.MyExpenses.WebApplication`
  
### Tests
  - run tests: `dotnet test`
