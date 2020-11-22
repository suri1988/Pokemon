# Pokemon
Pokemon repo for TrueLayer - This is a simple RESTful API, that given a valid Pokemon character, will return the name, along with a 'Shakespearan Description' of the character, if one such exists.

# Sources
- https://funtranslations.com/api/shakespeare
- https://pokeapi.co/
- Use of both the MS dotnetcore docs + Google for my simplified exponential backoff 

# Assumptions:
- I am using the characteristic function, of the Poke API call, since that is the closest I could find to an actual description.

# Stack Used:
- Dotnetcore 3.1

# Areas for Improvement:
- The free version of the Shakespearan API limits API requests, so ideally I would be checking for a 429 response code, and implmenting some sort of wait/retry mechanism, before making the next call based on the specific rate limit. Instead what I have here is a very basic version of retry, sourced from a basic version of an exponential backoff (increase rest time with each request). This means that hitting this can cause a 404, when in reality, it's actually a 429.
- Since there is no complicated controller logic, I don't have integration tests, but rather focused on the service layer where all the logic is situated
- Honestly a bit rusty with dotnetcore error handling - definitely can be cleaned up
- Some of the Serialized Json responses can be framed better, by using JsonProperty and following C# naming conventions
- For a production app, depending on how its used, I'd probably make all ther API requests follow the async/await pattern

# How to run the solution:
- Install dotnetcore: https://dotnet.microsoft.com/download
- Install Git: https://git-scm.com/download
- Clone the repo into a folder of your choice: git clone git@github.com:suri1988/Pokemon.git
- Make sure you are on branch master: git fetch && git reset --hard origin/master
- At this point, you should have everything needed to build and run the solution
- cd Pokemon/Pokemon within the cloned directory
- dotnet run
The endpoint is now ready. You can access it as follows:
curl --location --request GET 'https://localhost:5001/api/Pokemon/charizard' \
--header 'Content-Type: application/json'

# Running Unit Tests 
- Navigate to the unit test folder: cd Pokemon.UnitTests
- dotnet test, to run the 5 unit tests included.
# Using Dockerfile:
1) docker build git@github.com:suri1988/Pokemon.git
2) docker images to get list of running images
3) docker run {imageId} created from Command 1 to start a container from this image. 
