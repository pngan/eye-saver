namespace eye_saver;

public class HideMessageIn20Seconds : IHideMessagePolicy
{
    public Task OkToHideMessage()
    {
        // return Task.Delay(1000);
        return Task.Delay(20000);
    }
}

