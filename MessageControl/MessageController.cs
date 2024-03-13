namespace eye_saver;


public class MessageController
{
    List<IShowMessagePolicy> _showMessagePolicies = new();
    List<IHideMessagePolicy> _hideMessagePolicies = new();

    public void RegisterShowMessagePolicy(IShowMessagePolicy policy)
    {
        _showMessagePolicies.Add(policy);
    }

    public void RegisterHideMessagePolicy(IHideMessagePolicy policy)
    {
        _hideMessagePolicies.Add(policy);
    }

    public  async Task ShowMessage()
    {
        foreach (var policy in _showMessagePolicies)
            await policy.OkToShowMessage().ConfigureAwait(ConfigureAwaitOptions.ContinueOnCapturedContext);
    }

    public  async Task HideMessage()
    {
        foreach (var policy in _hideMessagePolicies)
            await policy.OkToHideMessage().ConfigureAwait(ConfigureAwaitOptions.ContinueOnCapturedContext);
    }
}

