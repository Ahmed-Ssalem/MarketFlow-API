# MarketFlow

MarketFlow is a .NET-based application designed to streamline the management of stores and products. The application implements robust CRUD operations for both entities, ensuring efficient data handling and operations. Built with modern architectural patterns such as Onion Architecture, Repository Pattern, and Unit of Work Pattern, MarketFlow aims to provide a scalable and maintainable solution for retail management.

## Features

- **Store Management**: Easily add, update, delete, and view stores.
- **Product Management**: Comprehensive CRUD operations for products.
- **Store-Product Relationship**: Manage many-to-many relationships between stores and products.
- **AutoMapper Integration**: Simplifies object-object mapping to enhance performance.
- **Entity Framework Core**: Leverages EF Core for data access and management.
- **Swagger Integration**: Built-in API documentation for easy testing and integration.
- **Repository Pattern**: Promotes a clean separation of concerns and code reusability.
- **Unit of Work Pattern**: Ensures atomic transactions and enhances data consistency.
- **Onion Architecture**: Provides a robust and scalable architecture that separates core domain logic from infrastructure concerns.


## Usage

### Store Management

- **Get All Stores**: `/api/store`
- **Get Store by ID**: `/api/store/{id}`
- **Create Store**: `/api/store`
- **Update Store**: `/api/store/{id}`
- **Delete Store**: `/api/store/{id}`

### Product Management

- **Get All Products**: `/api/product`
- **Get Product by ID**: `/api/product/{id}`
- **Create Product**: `/api/product`
- **Update Product**: `/api/product/{id}`
- **Delete Product**: `/api/product/{id}`


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

