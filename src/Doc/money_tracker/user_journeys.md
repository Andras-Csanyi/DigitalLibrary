#Money Tracker user journeys
 - Managing expenses
 - Managing incomes
 - Manage partners
 - Automated reports
 - Manage categories
 - Manage budget
 - Upload transaction list

The following cases should be covered by functionality.

## Being able to determine cost structure
The point is to have a deeper picture about one's financial situation. It means source of the incomes, whether
it is salary or investment. What is the biggest cost item, like renting a flat, or spending too much on booze.

## Managing investments
When investment happens, it lowers the cash-flow, so it is an expense, but the money gets a place where it will,
hopefully, produce some level of interest. From this point of view it differs from other expense items.

We want to be able to differentiate cost of living expenses from investments. Categories are for this purpose.
Moreover, we would like to have the ability to setup expectations for investments and real results, so, it is
possible to check whether it reached the expectations or not.

Another viewpoint for investments is risk. We would like to have the ability to differentiate risk levels.

There are investments where we cannot define and measure the expectations or these to vague, for example, I buy a
book or a training material in order to get a new job. What are my interest related expectations here? 
Can't be really defined. They are rather items for a goal, but still investments.

All of the differentiations above will have reporting and analytics.

## Managing cost of living
Cost of living on a month includes utilities, food and clothes, or any other the user consider belonging to
this category.

## Managing partners
One of the possible viewpoint of the cost structure is that where the money is spent. It means partners, which
a kind of artificial definition here, and cover shops, groceries and other places. Partner is mandatory field.

Dataset:
 - partner name
 - address
 
## Management of categories
Category is arbitrary information of an expense/income item. It is the main datapoint used for grouping expense/
income items. There are multiple type of category where the properties are different, like simple expense/income
category, investment category where risk, expected and real interest can be added, etc.

Dataset:
 - name
 - description
 - income or expense category
 - interest rate
 - real interest rate
 - expected interest rate
 - risk level
 
## Management of budget
Budget is an arbitrary information for category. The user can define how much is a budget for a given period of time.
The software helps him/her to track where they are in the budget.
Budget a good tool to track spends on cigarette, alcohol or any other expense type. Also good tool to track whether
the investment provided the expected outcome or not.

## Managing Expenses
 Managing expenses means that the user will get CRUD functionality for his/her
 expenses.
 Data of an expense item:
  - partner (where the money was spent)
  - amount
  - currency
  - items
  - budget
  - date
  - comment
  - expense id
  
## Managing incomes
The user will get CRUD functionality to manage these items.
Dataset of an income item:
 
 - Partner
 - amount
 - currency
 - budget
 - date
 - comment
 - income id 
 
## Managing partners
The user will get a CRUD functionality to manage partners.