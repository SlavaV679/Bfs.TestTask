using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bfs.TestTask.Driver;

public class CardDriverMock : ICardDriverMock
{
    private CardData? _cardData;

    private EjectResult _ejectResult = EjectResult.Ejected;

    public async Task<CardData?> ReadCard(CancellationToken cancellationToken)
    {
        await Task.Delay(200, cancellationToken);

        return cancellationToken.IsCancellationRequested
            ? null
            : _cardData;
    }

    public IAsyncEnumerable<EjectResult> EjectCard(CancellationToken cancellationToken)
    {

        //for (int i = 0; i < 3; i++)
        //{
        //    yield return cancellationToken.IsCancellationRequested
        //                ? EjectResult.Retracted
        //                : _ejectResult;
        //}

        throw new NotImplementedException();
    }

    public void SetCardData(CardData cardData)
    {
        _cardData = cardData;
    }

    public void CantReadCard()
    {
        _cardData = null;
    }

    public void TakeCard()
    {
        _ejectResult = EjectResult.CardTaken;
    }
}