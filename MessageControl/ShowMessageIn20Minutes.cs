namespace eye_saver;

public class ShowMessageIn20Minutes : IShowMessagePolicy
{
    public Task OkToShowMessage()
    {
        // return Task.Delay(5000);
        return Task.Delay(1200000);
    }
}

