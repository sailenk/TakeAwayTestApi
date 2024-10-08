This is a demo solution for the Take Away Test, built with .NET 8 using SQLite. It includes tests written with NUnit and Moq. You can run it directly in VS Code or Visual Studio, and test the API endpoints using either POSTMAN, .NET's built-in testing features, or Swagger. Due to time constraints, logging, authentication, authorization, and token services were not included. The primary focus of this project is to demonstrate REST API CRUD operations.

Data Models

1. Listings
2. UserSavedListings
3. Users

<table>
  <th>Listings</th>
  <tr>
    <td>
      Field
    </td>
    <td>
      Definition
    </td> 
  </tr>
  <tr>
    <td>
      id
    </td>
    <td>
      Numeric, Autoincremental, PK
    </td> 
  </tr>
  <tr>
    <td>
      Address
    </td>
    <td>
      Text
    </td> 
  </tr>
  <tr>
    <td>
      Suburb
    </td>
    <td>
      Text
    </td> 
  </tr>
  <tr>
    <td>
      State
    </td>
    <td>
      Text
    </td> 
  </tr>
  <tr>
    <td>
      Postcode
    </td>
    <td>
      Numeric (4)
    </td> 
  </tr>
</table>

<table>
  <th>Users</th>
  <tr>
    <td>
      Field
    </td>
    <td>
      Definition
    </td> 
  </tr>
  <tr>
    <td>
      id
    </td>
    <td>
      Numeric, Autoincremental, PK
    </td> 
  </tr>
  <tr>
    <td>
      FirstName
    </td>
    <td>
      Text
    </td> 
  </tr>
  <tr>
    <td>
      LastName
    </td>
    <td>
      Text
    </td> 
  </tr>
  <tr>
    <td>
      Email
    </td>
    <td>
      Text
    </td> 
  </tr>
  <tr>
    <td>
      DateCreated
    </td>
    <td>
      Datetime
    </td> 
  </tr>
  <tr>
    <td>
      DateUpdated
    </td>
    <td>
      Datetime
    </td> 
  </tr>
</table>

<table>
  <th>UserSavedListings</th>
  <tr>
    <td>
      Field
    </td>
    <td>
      Definition
    </td> 
  </tr>
  <tr>
    <td>
      id
    </td>
    <td>
      Numeric, Autoincremental, PK
    </td> 
  </tr>
  <tr>
    <td>
      ListingId
    </td>
    <td>
      Numeric, FK
    </td> 
  </tr>
  <tr>
    <td>
      UserId
    </td>
    <td>
      Numberic, FK
    </td> 
  </tr>
  <tr>
    <td>
      IsShortListed
    </td>
    <td>
      Bit
    </td> 
  </tr>
  <tr>
    <td>
      DateAdded
    </td>
    <td>
      Datetime
    </td> 
  </tr>
  <tr>
    <td>
      DateUpdated
    </td>
    <td>
      Datetime
    </td> 
  </tr>
</table>

Please run to initialize database - create (if required)
<br>
dotnet ef migrations add <name>
<br>
dotnet ef database update         

