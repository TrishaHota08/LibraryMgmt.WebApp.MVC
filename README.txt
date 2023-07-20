LibraryMgmt.WebApp.MVC Project - README
Welcome to the README file for my 'LibraryMgmt.WebApp.MVC' project! This web application is designed to manage a library system and includes various functionalities to handle books, customers, and orders. The project follows the Model-View-Controller (MVC) architectural pattern to ensure separation of concerns and maintainability.

Assumption made: 
1. this tool will be used by the library staffs for CRUD operations for Books, Customers, Orders.
2. The logo is alos a button to navigate to Home page.

Functionalities
Add Book: This functionality allows users to add new books to the library catalog.

View All Books: Users can view a list of all books in the library.

View All Available Books: This feature displays a list of books that are currently available for borrowing.

Delete Available Book: Users can delete a book from the available books list that are present in the library.

Add Customer: Users can add new customers to the library system.

View All Customers: This functionality provides a list of all registered customers in the library.

View All Orders: Users can view all the orders placed in the library.

Add Order: This feature allows users to place new orders for books.

Architectural Design Pattern - MVC
The project is designed following the Model-View-Controller (MVC) pattern, which ensures a clear separation of concerns between data models (Model), user interface and presentation logic (View), and request handling and business logic (Controller). This design pattern enhances maintainability and reusability of code.

Razor View and View Components
The user interface is developed using Razor views and View components. Razor is a powerful templating engine for ASP.NET Core that enables seamless integration of server-side code with HTML. 


Frontend Technologies
The frontend part of the project is built using HTML, CSS, and Bootstrap 5. Bootstrap provides a responsive and visually appealing UI design, making the application look professional and user-friendly.

Tag Helpers
Tag Helpers in ASP.NET Core allow server-side code to participate in the rendering of HTML elements. They simplify the process of generating HTML by enabling the use of custom attributes and behavior for specific HTML elements.
Tag helpers used:
- asp-controller, asp-action for the a tag.
-made custom tag helper for email.

View Components
View Components in ASP.NET Core provide a way to create reusable, self-contained UI components that can be rendered within views. They promote code reusability and enable the creation of complex UI elements.
The view components created:
BookList- For the drop down list for the booklists available to be issued, used in the New Order section.
Contact- For the ContactUS component.

Razor Pages
Razor Pages is a feature of ASP.NET Core that enables the creation of page-focused endpoints. It simplifies the development of UI-focused pages without the need for separate controllers, making it easier to maintain and understand the codebase.
Created razor pages:
- DeleteBook- the Razor page is used for the deleteBook functionality with implementation for SuccessPage and ErrorPage as the redirection from the Delete operation.

Client-Side Input Validation
Client-side input validation ensures that users enter valid data before submitting forms. It improves user experience by providing instant feedback on input errors, reducing the number of unnecessary server requests.
Custom validation attributes are also added:|
-DateGreaterThan Attribute (validation based for date comparison)
-PositiveNumber Attribute (validation for user input for only positive numbers expected)

Data Transfer with AutoMapper
AutoMapper is used to simplify the mapping process between server-client Data transfer. Auto mapper is used to map all the DTOs present in the Server side  to the client side DTOs and vice versa.


Authentication and Authorization
Authentication and authorization are implemented using Cookie Authentication for user login and session management.
 For API calls from each functionality, JSON Web Token (JWT) is used to ensure secure and authenticated access.

Libraries used:
1. AutoMapper (For mapping of clientside- server side data transfer)
2. AutoMapper.Extensions.Microsoft.DependencyInjection"

Prerequisite:
## The 'LibraryMgmt.WebAPI' project and this WebApp project should be under same parent directory due to the project reference path dependency.
1. The database: LibDB_final is created using the migration tool of EF core.
2.The database tables are seeded with the initial data.
3.The 'LibraryMgmt.WebAPI' project is built and up and running in "http://localhost:5191".
NOTE: In case, the WebAPI project is running is a different port, update the same in the appsettings.json file of this 'LibraryMgmt.WebApp.MVC' project for 'BaseUrl'.

Steps To Setup:
1. Once all the above prerequisties are confirmed, build the 'LibraryMgmt.WebApp.MVC' project.
2. On build successful, check the appUrl for the project under launchSettings.json and make sure the application WILLNOT be hosted (both on IIS server and built in server) on the same port as the WebAPI.
3.Once confirmed, run the application.
4.On the login page being up, enter the credentials:
email: admin@libraryuae.com
password: admin123
(In case you want to use any other user credential, please refer the table provided in my WEB API project README file for all the existing staff tables.
NOTE: For the New Order funcionality - place order form submission, remember to use the staff id(1, 2, 3) for staff id input as currently no new entry for staff table is allowed and by default staff table consists of 3 staffs.

Conclusion
Our ASP.NET Core WebApp project incorporates various functionalities to manage a library system efficiently. The adoption of the MVC architectural pattern, along with Razor views and components, ensures a structured and maintainable codebase. The implementation of concepts such as tag helpers, view components, and Razor pages for enhancing the UI development experience and code reusability. Client-side input validation and AutoMapper streamline data processing and user interactions during server-client communication. The authentication and authorization mechanisms using Cookie Authentication and JWT secure user access effectively. 
For any questions or issues, feel free to reach out to my mail trisha.hota@gmail.com.





