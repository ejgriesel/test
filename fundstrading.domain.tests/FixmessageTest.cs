using fundstrading.domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fundstrading.domain.tests
{
    [TestClass]
    public class FixmessageTest
    {

        [TestMethod]
        public void TestParseFixTag()
        {
            Fixmessage fixmessage = new Fixmessage();
            fixmessage.Raw = "8=FIX.4.4\0128=KRUGER\09=584\035=o\049=AFE\056=PYIRESSTEST\0115=FNBWI\0513=308b7a36-cb8f-4e7b-92ce-fd6e51ed762b\0514=0\0473=1\0509=1\0522=1\020001=1\020002=Tribbiani\020003=Joey\020004=J\020005=1\020006=Eng\020007=donotcontact@iress.co.za\020008=+27 21 553 2292\020009=+27 21 657 8808\020010=+27 72 832 2004\020011=2\020012=19770120\020013=1\020014=7701205227081\020016=710\020018=Bellville\020019=2259957161\020020=710\020021=710\020022=Y\020023=710\020030=Unit 48\020031=Amble Way\020032=Melkbosstrand\020033=Cape Town\020034=Western Cape\020035=7440\020047=1\020026=271562748\020024=Milnerton\020025=051001\020027=1\020028=J Tribbiani\020029=F9526C2NH0\010=210\0";
            Assert.AreEqual("AFE", fixmessage.SenderCompID);
            Assert.AreEqual("PYIRESSTEST", fixmessage.TargetCompID);
            Assert.AreEqual("FNBWI", fixmessage.OnBehalfOfCompID);
            Assert.AreEqual("308b7a36-cb8f-4e7b-92ce-fd6e51ed762b", fixmessage.RegistID);
            Assert.AreEqual("0", fixmessage.RegistTransType);
            Assert.AreEqual("1", fixmessage.NoRegistDtls);
            Assert.AreEqual("1", fixmessage.RegistDtls);
            Assert.AreEqual("1", fixmessage.OwnerType);
            Assert.AreEqual("KRUGER", fixmessage.DeliverToCompID);
        }

        [TestMethod]
        public void TestParseFixTagWhenNoExist()
        {
            Fixmessage fixmessage = new Fixmessage();
            //Tag 115 not in the below fix msg
            fixmessage.Raw = "8=FIX.4.4\09=584\035=o\049=AFE\056=PYIRESSTEST\0513=308b7a36-cb8f-4e7b-92ce-fd6e51ed762b\0514=0\0473=1\0509=1\0522=1\020001=1\020002=Tribbiani\020003=Joey\020004=J\020005=1\020006=Eng\020007=donotcontact@iress.co.za\020008=+27 21 553 2292\020009=+27 21 657 8808\020010=+27 72 832 2004\020011=2\020012=19770120\020013=1\020014=7701205227081\020016=710\020018=Bellville\020019=2259957161\020020=710\020021=710\020022=Y\020023=710\020030=Unit 48\020031=Amble Way\020032=Melkbosstrand\020033=Cape Town\020034=Western Cape\020035=7440\020047=1\020026=271562748\020024=Milnerton\020025=051001\020027=1\020028=J Tribbiani\020029=F9526C2NH0\010=210\0";
            Assert.AreEqual(null, fixmessage.OnBehalfOfCompID);

        }
    }
}
