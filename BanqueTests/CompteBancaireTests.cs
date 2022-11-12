using System.Security.Principal;
using CompteBanqueNS;

namespace BanqueTests;

[TestClass]
public class CompteBancaireTests
{
    [TestMethod]
    public void VérifierDébitCompteCorrect()
    {
        double soldeInitial = 500000;
        double montantDébit = 400000;
        double soldeAttendu = 100000;

        var compte = new CompteBancaire("Awaby", soldeInitial);

        compte.Débiter(montantDébit);

        double soldeObtenu = compte.Balance;
        Assert.AreEqual(soldeAttendu, soldeObtenu, 0.001, "Compte débité incorrectement");
    }

    [TestMethod]
    public void DébiterMontantSupérieurSoldeLèveArgumentOutOfRange ()
    {
        double soldeInitial = 500000;
        double montantDébit = 600000;
        //double soldeAttendu = 100000;

        var compte = new CompteBancaire("Awaby", soldeInitial);

        compte.Débiter(montantDébit);

        //double soldeObtenu = compte.Balance;
        Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => compte.Débiter(montantDébit));
    }

    [TestMethod]
    public void DébiterMontantNégatifLèveArgumentOutOfRange ()
    {
        double soldeInitial = 500000;
        double montantDébit = -600000;
        //double soldeAttendu = 100000;

        var compte = new CompteBancaire("Awaby", soldeInitial);

        compte.Débiter(montantDébit);

        //double soldeObtenu = compte.Balance;
        Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => compte.Débiter(montantDébit));
    }
}
