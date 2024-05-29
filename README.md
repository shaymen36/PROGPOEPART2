# PROGPOEPART2
INSTRUCTIONS FOR HOW TO COMPILE AND RUN THE SOFTWARE:
Prerequisites:
You need to have .NET Core SDK installed on your system.
Steps to Compile and Run:
Clone the Repository:

Clone the repository containing your recipe application code from GitHub to your local machine.
Navigate to the Project Directory:

Open a terminal or command prompt.
Use the cd command to navigate to the directory where your project is located.
Compile the Application:

Use the following command to build the application:
Copy code
dotnet build
Run the Application:

Once the build process is successful, use the following command to run the application:
arduino
Copy code
dotnet run
This will execute the Main method in your Program class, starting the recipe application.
Follow the On-Screen Instructions:

Once the application is running, you will see a menu with options displayed in the console.
Follow the on-screen instructions to interact with the application, such as adding recipes, displaying recipes, scaling recipes, etc.
Enter the corresponding option number based on your desired action.
Exit the Application:
To exit the application, select the option to exit (usually option 0).

https://github.com/shaymen36/PROGPOEPART2.git

BRIEF DESCRIPTION OF WHAT I CHANGED BASED ON MY LECTURER'S FEEDBACK:
In enhancing the error handling of the recipe application, several advanced features were employed to enhance user experience and application reliability. A notable enhancement was the implementation of colored text for error messages, utilizing console color codes to distinguish error messages from regular output. This improves the readability of errors and provides visual cues, aiding in better user understanding and response.
The integration of try-catch blocks in critical code sections, such as user input processing and recipe manipulation, demonstrates a proactive error handling approach. By encapsulating potentially error-prone code within try blocks and catching exceptions with catch blocks, the application can gracefully recover from unexpected errors, preventing crashes and offering meaningful error messages to users.
Furthermore, an issue regarding the 'reset quantities' feature after ingredient scaling was addressed. Implementing a solution to reset ingredient quantities to their original values post-scaling ensures data accuracy and consistency, enhancing application functionality and providing users with a reliable experience when manipulating recipes.
Overall, these enhancements showcase a commitment to advanced features for improved user experience, robust error handling techniques for risk mitigation, and prompt resolution of functional issues to maintain application reliability. These efforts align with best practices in software development, contributing to the quality and usability of the application.
