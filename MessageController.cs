namespace eye_saver;
using System.Threading.Tasks;

public class MessageController
{

    public static async Task WaitForMessageOn()
    {
        await Task.Delay(5000).ConfigureAwait(ConfigureAwaitOptions.ContinueOnCapturedContext);
        // await Task.Delay(1200000).ConfigureAwait(ConfigureAwaitOptions.ContinueOnCapturedContext);
    }

    public static async Task WaitForMessageOff()
    {
        await Task.Delay(1000).ConfigureAwait(ConfigureAwaitOptions.ContinueOnCapturedContext);
        // await Task.Delay(20000).ConfigureAwait(ConfigureAwaitOptions.ContinueOnCapturedContext);
    }
}