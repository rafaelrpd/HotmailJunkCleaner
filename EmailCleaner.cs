using System;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using Microsoft.Extensions.Configuration;
using MimeKit;

public class EmailCleaner
{
    private readonly IConfiguration _config;

    public EmailCleaner(IConfiguration config)
    {
        _config = config;
    }

    public async Task CleanJunkEmailsAsync(string textToDelete)
    {
        using var client = new ImapClient();
        await client.ConnectAsync(_config["Hotmail:ImapServer"], 993, true);
        await client.AuthenticateAsync(_config["Hotmail:Email"], _config["Hotmail:Password"]);

        var junk = client.GetFolder(_config["Hotmail:JunkFolder"]);
        await junk.OpenAsync(FolderAccess.ReadWrite);

        var uids = await junk.SearchAsync(SearchQuery.All);
        foreach (var uid in uids)
        {
            var message = await junk.GetMessageAsync(uid);
            if (message.TextBody != null && message.TextBody.Contains(textToDelete, StringComparison.OrdinalIgnoreCase))
            {
                await junk.AddFlagsAsync(uid, MessageFlags.Deleted, true);
            }
        }

        await junk.ExpungeAsync();
        await client.DisconnectAsync(true);
    }
}
