# Pokemon
Pokemon repo for TrueLayer

This is a simple RESTful API, that given a valid Pokemon character, will return the name, along with a 'Shakespearan Description' of the character. 
Following APIs are used:
- https://funtranslations.com/api/shakespeare
- https://pokeapi.co/

Assumptions:
- I am using the characteristic function, of the Poke API call, since that is the closest I could find to an actual description.

Stack Used:
- Dotnetcore

Areas for Improvement:
- The free version of the Shakespearan API limits API requests, so ideally I would be checking for a 429 response code, and implmenting some sort of wait/retry mechanism,
before making the next call
- Since there is no complicated controller logic, I don't have integration tests, but rather focused on the service layer where all the logic is situated
