namespace ACE.Server.Network.Enum
{
    public enum SessionState
    {
        AuthLoginRequest,
        WorldLoginRequest,
        AuthConnectResponse,
        WorldConnectResponse,
        AuthConnected,
        WorldConnected,
        TerminationStarted,
    }
}
