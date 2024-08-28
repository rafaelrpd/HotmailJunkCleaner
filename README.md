# HotmailJunkCleaner

HotmailJunkCleaner is a C# console application that automatically cleans junk emails from a Hotmail/Outlook account based on specific text content.

## Prerequisites

- [Download .NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [A Hotmail/Outlook account with IMAP access enabled](https://support.microsoft.com/en-us/office/pop-imap-and-smtp-settings-for-outlook-com-d088b986-291d-42b8-9564-9c414e2aa040)

## Setup

1. Clone the repository:
   ```
   git clone https://github.com/rafaelrpd/HotmailJunkCleaner.git
   cd HotmailJunkCleaner
   ```

2. Open the `appsettings.json` file and update it with your email credentials:
   ```json
   {
     "Hotmail": {
       "ImapServer": "outlook.office365.com",
       "Email": "your-email@outlook.com",
       "Password": "your-password",
       "JunkFolder": "Junk"
     }
   }
   ```
   Replace `your-email@outlook.com` with your actual email address and `your-password` with your account password.

## How to Use

1. Build the project:
   ```
   dotnet build
   ```

2. Run the application:
   ```
   dotnet run
   ```

3. The application will automatically:
   - Connect to your Hotmail/Outlook account
   - Access the Junk Email folder
   - Search for emails containing the specified text
   - Delete matching emails

4. By default, the application searches for emails containing "Get Rich". To change this:
   - Open `Program.cs`
   - Locate the line: `await cleaner.CleanJunkEmailsAsync("Get Rich");`
   - Replace "Get Rich" with your desired search text

5. To change other settings:
   - Email server: Update the "ImapServer" value in `appsettings.json`
   - Junk folder name: Update the "JunkFolder" value in `appsettings.json`

## Troubleshooting

If you encounter issues:

1. Ensure your email and password are correct in `appsettings.json`
2. Verify that IMAP is enabled for your Outlook account
3. If you use two-factor authentication, you may need to create an app password:
   - Go to https://account.live.com/proofs/AppPassword
   - Sign in and follow the prompts to create an app password
   - Use this app password in `appsettings.json` instead of your regular password

## Security Note

Be cautious when storing passwords in configuration files. For production use, consider using environment variables or a secure secret management system.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
