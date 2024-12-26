 Selenium Test Automation Project

This repository contains Selenium-based test automation scripts for validating various functionalities of the **DemoBlaze** https://www.demoblaze.com/index.html  web application. The tests are written in C# and utilize Selenium WebDriver for UI interactions.

## Features Tested

### Functional Tests
1. **Register Test**: Validates the registration functionality with both valid and invalid inputs.
2. **Login Test**: Tests the login functionality with valid credentials and error handling for incorrect inputs.
3. **Add to Cart Test**: Ensures products can be added to the cart successfully.
4. **Delete from Cart Test**: Verifies the ability to remove items from the cart.
5. **Place Order Test**: Tests the checkout process, including filling in order details and completing the purchase.
6. **Contact Form Test**: Validates the contact form functionality with valid email, name, and message inputs.

### Performance Tests
1. **Page Load Performance**: Measures the time taken to load the homepage and verifies it loads within 3 seconds.

## Prerequisites
- **.NET SDK** (latest version)
- **Selenium WebDriver**
- **ChromeDriver**
- **Visual Studio Code** or any C# IDE
- **Git** for version control


## Running Tests

1. Open the terminal and navigate to the project directory.
2. Run specific test files using:
   ```bash
   dotnet run
   ``

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Author
Nurul Afifah Muthoharoh
