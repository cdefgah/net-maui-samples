# Send text via email

Edit the `AndroidManifest.xml` file and add this section:

```xml
<queries>
    <intent>
        <action android:name="android.intent.action.SENDTO" />
        <data android:scheme="mailto" />
    </intent>
</queries>
```

If the `queries` section already exists in your project, only add the `intent` XML node.

Use the following code to open the email client with a predefined subject, recipient address, and email body:

```c#
try
{
    var emailMessage = new EmailMessage
    {
        Subject = "Your email subject",
        Body = "Here's the some text you want to send",
        To = ["recipient@somemail.com"]
    };

    await Email.Default.ComposeAsync(emailMessage);
}
catch (FeatureNotSupportedException)
{
    // If email client is not properly configured
    // process exception, display message or re-throw exception
}
catch (Exception ex)
{
    // If some general error occurs
    // process exception, display message or re-throw exception
}
```

Check git log for changes with the tag: `AndroidSendTextViaEmail`.