# MyExpenses

Project to control personal expenses written in C# and dotnet core.

| Status master & dev |
| ---------     |
| [![Build status](https://ci.appveyor.com/api/projects/status/ruct5xtn0w0kjg9u?svg=true)](https://ci.appveyor.com/project/lfmachadodasilva/myexpenses-92x3x) |
| [![Codacy Badge](https://api.codacy.com/project/badge/Grade/dd4c1a6d69fb476e8b2a7be6800d4b6d)](https://www.codacy.com/app/lfmachadodasilva/MyExpenses?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=lfmachadodasilva/MyExpenses&amp;utm_campaign=Badge_Grade) |
| [![codecov](https://codecov.io/gh/lfmachadodasilva/MyExpenses/branch/master/graph/badge.svg)](https://codecov.io/gh/lfmachadodasilva/MyExpenses) |
| [![Average time to resolve an issue](http://isitmaintained.com/badge/resolution/lfmachadodasilva/MyExpenses.svg)](http://isitmaintained.com/project/lfmachadodasilva/MyExpenses "Average time to resolve an issue") |
| [![Percentage of issues still open](http://isitmaintained.com/badge/open/lfmachadodasilva/MyExpenses.svg)](http://isitmaintained.com/project/lfmachadodasilva/MyExpenses "Percentage of issues still open") |



<img src="http://yuml.me/diagram/scruffy/class/[IModel|Id:long{bg:orange}]], [Expense|Name:string;Value:float;Date:Date;IsIncoming:bool;Label:Label;Payment:Payment], [Label|Id:long;Name:string], [Payment|Id:long;Name:string], , [IModel]^-.-[Expense], [IModel]^-.-[Label], [IModel]^-.-[Payment], [Expense]1-0..*[Label], [Expense]1-0..*[Payment]"/>
