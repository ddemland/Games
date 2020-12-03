
using System;

namespace BlackJack.Engine
{
    public class NoCards : Exception
    {
    }

    public class MaxCardInHand : Exception
    {
    }

    public class HandBusted : Exception
    {
    }

    public class HandHeld : Exception
    {
    }

    public class PlayerAlreadyExist : Exception
    {
    }

    public class MaxPlayers : Exception
    {
    }

    public class PlayerDoesNotExist : Exception
    {
    }
}
