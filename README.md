# SuperCharacterApp
### The application mimics sort of RPG game.

**Currently CRUD operations implemented only.**

Repository pattern with Unit of Work.

#### Used third party libraries and other technology stack information:

    
* ASP.NET CORE v2.2   
* EF Core
* X.PagedList - Used for pagination -> https://github.com/dncuug/X.PagedList
* Shouldly - Used in my unit tests  -> https://github.com/shouldly/shouldly
* AutoMapper - used to map DTO to models and vice versa -> https://github.com/AutoMapper/AutoMapper
* XUnit - framework for unit testing -> https://xunit.github.io/


Used InMemory Db instead mocking for the unit tests.


TODO:
1. Add following fields to 'Team', 
'Superhero' and 'Supervillain'(must not be included in add/edit UI, can be shown in the list view)
* Wins:
* Loses: 

2. 1vs1 turn-based combat, hero vs villain
