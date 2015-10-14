// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlHelperTests.cs" company="tym32167">
//   Muradov Artem
// </copyright>
// <summary>
//   Defines the HtmlHelperTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Calculon.Tests
{
  using Calculon.Lib;

  using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

  /// <summary>
  /// The html helper tests.
  /// </summary>
  [TestClass]
  public class HtmlHelperTests
  {
    /// <summary>
    /// The test 1.
    /// </summary>
    [TestMethod]
    public void Test1()
    {
      const string Markup = @"Version:1.0
StartHTML:00000097
EndHTML:00000363
StartFragment:00000153
EndFragment:00000330
<!DOCTYPE><HTML><HEAD></HEAD><BODY><!--StartFragment -->
<div><div style=""-ms-word-wrap: break-word; -webkit-nbsp-mode: space; -webkit-line-break: after-white-space;""><div>54.96+235+235+588.26+3571.99+334.40+720.42</div></div></div>
<!--EndFragment --></BODY></HTML>";
      var result = HtmlHelper.RemoveTags(Markup);
      Assert.AreEqual("54.96+235+235+588.26+3571.99+334.40+720.42", result);
    }

    /// <summary>
    /// The test 2.
    /// </summary>
    [TestMethod]
    public void Test2()
    {
      const string Markup = @"body {
font-family:""Segoe UI"";
font-size:11pt;
font-weight:300;
letter-spacing:0.29px;
line-height:19.99px;
}

.title {
display:block;
margin:10px;
}

.winTile {
padding:20px;
background-color:#FFF;
width:520px;
margin-top:10px;
}

ul, h1, h2, h3, li {
padding:0;
margin:0;
}

li {
list-style-type:none;
}

li.miniTile {
display:inline-block !important;
margin-right:0 !important;
}

a, cite {
text-decoration:none;
font-style:normal;
}
sss - BingSSS.RU - Главная страницаwww.sss.ruВо-первых, здравствуйте! На редких сайтах Вы найдёте приветствие. Не принято почему-то ... sss_sss_ssssss-sss-sss.livejournal.comЯ сейчас только про дизайн. Остался добродушный вид лягушонка, даже еще более смешной и ... SSS@sss, Светланаssssss.www.nn.ruИнформация о пользователе SSS@sss. Настоящее имя - Светлана. Родилась 25 Июня 1983г в городе ...";
      var result = HtmlHelper.RemoveTags(Markup);
      Assert.AreEqual("sss - BingSSS.RU - Главная страницаwww.sss.ruВо-первых, здравствуйте! На редких сайтах Вы найдёте приветствие. Не принято почему-то ... sss_sss_ssssss-sss-sss.livejournal.comЯ сейчас только про дизайн. Остался добродушный вид лягушонка, даже еще более смешной и ... SSS@sss, Светланаssssss.www.nn.ruИнформация о пользователе SSS@sss. Настоящее имя - Светлана. Родилась 25 Июня 1983г в городе ...", result);
    }

    /// <summary>
    /// The test 3.
    /// </summary>
    [TestMethod]
    public void Test3()
    {
      const string Markup = "Version:1.0\r\nStartHTML:00000097\r\nEndHTML:00005078\r\nStartFragment:00000153\r\nEndFragment:00005045\r\n<!DOCTYPE><HTML><HEAD></HEAD><BODY><!--StartFragment --><style>\r\nbody {\nfont-family:\"Segoe UI\";\nfont-size:11pt;\nfont-weight:300;\nletter-spacing:0.29px;\nline-height:19.99px;\n}\n\n.title {\ndisplay:block;\nmargin:10px;\n}\n\n.winTile {\npadding:20px;\nbackground-color:#FFF;\nwidth:520px;\nmargin-top:10px;\n}\n\nul, h1, h2, h3, li {\npadding:0;\nmargin:0;\n}\n\nli {\nlist-style-type:none;\n}\n\nli.miniTile {\ndisplay:inline-block !important;\nmargin-right:0 !important;\n}\n\na, cite {\ntext-decoration:none;\nfont-style:normal;\n}\n</style><a class=title href=\"www.bing.com/search?q=sssd\"><h2>sssd - Bing</h2></a><li tabindex=1 class=\"sa_wr winTile oneRow snapOneRow win-item\" id=ms__id55><div class=sa_cc style=\"border-color:rgb(51, 51, 51);transform-origin:260px 52.49px;perspective-origin:260px 52.49px;width:520px;height:104.98px;color:rgb(51, 51, 51);line-height:19px;list-style-type:none;column-rule-color:rgb(51, 51, 51);\"><div class=sa_mc><div class=sb_tlst style=\"transform-origin:260px 16px;perspective-origin:260px 16px;height:32px;margin-top:-7px;margin-bottom:8px;\"><h2 style=\"line-height:29px;letter-spacing:0.53px;font-size:26.66px;font-weight:200;page-break-after:avoid;\"><a tabindex=-1 style=\"line-height:32px;display:inline;cursor:pointer;\" href=\"http://sssd.ru/\"><strong>SSSD</strong>.ru Скидки Уфа Стерлитамак / Кино ...</a></h2></div><div class=sb_meta style=\"transform-origin:260px 9.33px;perspective-origin:260px 9.33px;height:18.66px;margin-bottom:9px;\"><cite style=\"border-color:rgb(102, 102, 102);color:rgb(102, 102, 102);display:inline;column-rule-color:rgb(102, 102, 102);\"><span class=sw_hlt style=\"border-color:rgb(56, 128, 32);color:rgb(56, 128, 32);column-rule-color:rgb(56, 128, 32);\"><strong style=\"font-weight:600;\">sssd</strong>.ru</span></cite></div><p style=\"transform-origin:260px 18.66px;perspective-origin:260px 18.66px;height:37.32px;\">Будь в курсе кинопремьер, новых выгодных скидок и акций в кафе, салонах красоты, spa, бутиках ...</p> </div></div></li><li tabindex=1 class=\"sa_wr winTile oneRow snapOneRow win-item\"><div class=sa_cc style=\"border-color:rgb(51, 51, 51);transform-origin:260px 52.49px;perspective-origin:260px 52.49px;width:520px;height:104.98px;color:rgb(51, 51, 51);line-height:19px;list-style-type:none;column-rule-color:rgb(51, 51, 51);\"><div class=sa_mc><div class=sb_tlst style=\"transform-origin:260px 16px;perspective-origin:260px 16px;height:32px;margin-top:-7px;margin-bottom:8px;\"><h2 style=\"line-height:29px;letter-spacing:0.53px;font-size:26.66px;font-weight:200;page-break-after:avoid;\"><a tabindex=-1 style=\"line-height:32px;display:inline;cursor:pointer;\" href=\"http://www.sssd.eu/?id=gallery\"><strong>SSSD</strong></a></h2></div><div class=sb_meta style=\"transform-origin:260px 9.33px;perspective-origin:260px 9.33px;height:18.66px;margin-bottom:9px;\"><cite style=\"border-color:rgb(102, 102, 102);color:rgb(102, 102, 102);display:inline;column-rule-color:rgb(102, 102, 102);\"><span class=sw_hlt style=\"border-color:rgb(56, 128, 32);color:rgb(56, 128, 32);column-rule-color:rgb(56, 128, 32);\">www.<strong style=\"font-weight:600;\">sssd</strong>.eu</span>/?id=gallery</cite></div><p style=\"transform-origin:260px 18.66px;perspective-origin:260px 18.66px;height:37.32px;\">Social Dialogue: the most important tool for socially responsible reforms in security sector</p> </div></div></li><li tabindex=1 class=\"sa_wr winTile oneRow snapOneRow win-item\"><div class=sa_cc style=\"border-color:rgb(51, 51, 51);transform-origin:260px 52.49px;perspective-origin:260px 52.49px;width:520px;height:104.98px;color:rgb(51, 51, 51);line-height:19px;list-style-type:none;column-rule-color:rgb(51, 51, 51);\"><div class=sa_mc><div class=sb_tlst style=\"transform-origin:260px 16px;perspective-origin:260px 16px;height:32px;margin-top:-7px;margin-bottom:8px;\"><h2 style=\"line-height:29px;letter-spacing:0.53px;font-size:26.66px;font-weight:200;page-break-after:avoid;\"><a tabindex=-1 style=\"line-height:32px;display:inline;cursor:pointer;\" href=\"http://sssd.ru/index.php?q=user/\">Информация о пользователе | <strong>SSSD</strong>.ru ...</a></h2></div><div class=sb_meta style=\"transform-origin:260px 9.33px;perspective-origin:260px 9.33px;height:18.66px;margin-bottom:9px;\"><cite style=\"border-color:rgb(102, 102, 102);color:rgb(102, 102, 102);display:inline;column-rule-color:rgb(102, 102, 102);\"><span class=sw_hlt style=\"border-color:rgb(56, 128, 32);color:rgb(56, 128, 32);column-rule-color:rgb(56, 128, 32);\"><strong style=\"font-weight:600;\">sssd</strong>.ru</span>/index.php?q=user</cite></div><p style=\"transform-origin:260px 18.66px;perspective-origin:260px 18.66px;height:37.32px;\">Укажите ваше имя на сайте <strong style=\"font-weight:600;display:inline;\">SSSD</strong>.ru Скидки Уфа Стерлитамак / Кино &amp; Театр Афиша.</p> </div></div></li><!--EndFragment --></BODY></HTML>";
      var result = HtmlHelper.RemoveTags(Markup);
      Assert.AreEqual(@"sssd - BingSSSD.ru Скидки Уфа Стерлитамак / Кино ...sssd.ruБудь в курсе кинопремьер, новых выгодных скидок и акций в кафе, салонах красоты, spa, бутиках ... SSSDwww.sssd.eu/?id=gallerySocial Dialogue: the most important tool for socially responsible reforms in security sector Информация о пользователе | SSSD.ru ...sssd.ru/index.php?q=userУкажите ваше имя на сайте SSSD.ru Скидки Уфа Стерлитамак / Кино &amp; Театр Афиша.", result);
    }
  }
}
