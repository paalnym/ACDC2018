using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DothrakiTranslatorService
{
    public static class DothrakiTranslatorService
    {
        [FunctionName("DothrakiTranslatorService")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "HttpTriggerCSharp/phrase/{phrase}")]HttpRequestMessage req, string phrase, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            TranslatorGroup[] translatorGroup = JsonConvert.DeserializeObject<TranslatorGroup[]>(JsonData);
            var dothrakiWord = translatorGroup.FirstOrDefault(p => p.English.ToLower().StartsWith(phrase.ToLower()));
            return req.CreateResponse(HttpStatusCode.OK, dothrakiWord);
        }

        public static string get_web_content(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string output = reader.ReadToEnd();
            response.Close();
            return output;
        }

        public class TranslatorGroup
        {
            public string English { get; set; }
            public string Dothraki { get; set; }
        }

        private static string JsonData = @"[
    {
        ""English"":  ""about"",
        ""Dothraki"":  ""qisi""
    },
    {
        ""English"":  ""above"",
        ""Dothraki"":  ""oleth""
    },
    {
        ""English"":  ""accurate sword strike"",
        ""Dothraki"":  ""hrakkarikh""
    },
    {
        ""English"":  ""ache"",
        ""Dothraki"":  ""athmharar""
    },
    {
        ""English"":  ""across"",
        ""Dothraki"":  ""yomme""
    },
    {
        ""English"":  ""act"",
        ""Dothraki"":  ""tikh""
    },
    {
        ""English"":  ""adult whose body was not burned"",
        ""Dothraki"":  ""lei ""
    },
    {
        ""English"":  ""advice"",
        ""Dothraki"":  ""zhillie""
    },
    {
        ""English"":  ""advice"",
        ""Dothraki"":  ""fonnoya""
    },
    {
        ""English"":  ""after"",
        ""Dothraki"":  ""irge""
    },
    {
        ""English"":  ""again"",
        ""Dothraki"":  ""save""
    },
    {
        ""English"":  ""alike"",
        ""Dothraki"":  ""akkate""
    },
    {
        ""English"":  ""alive"",
        ""Dothraki"":  ""thir""
    },
    {
        ""English"":  ""all along"",
        ""Dothraki"":  ""evoon""
    },
    {
        ""English"":  ""all"",
        ""Dothraki"":  ""ei""
    },
    {
        ""English"":  ""ally"",
        ""Dothraki"":  ""kemik""
    },
    {
        ""English"":  ""almost"",
        ""Dothraki"":  ""chir""
    },
    {
        ""English"":  ""along"",
        ""Dothraki"":  ""vi""
    },
    {
        ""English"":  ""already"",
        ""Dothraki"":  ""ray""
    },
    {
        ""English"":  ""also"",
        ""Dothraki"":  ""akka""
    },
    {
        ""English"":  ""always"",
        ""Dothraki"":  ""ayyey""
    },
    {
        ""English"":  ""an extremely large number"",
        ""Dothraki"":  ""yorosor""
    },
    {
        ""English"":  ""An image or symbol depicted on a tattoo"",
        ""Dothraki"":  ""lirikh""
    },
    {
        ""English"":  ""an instance of blocking"",
        ""Dothraki"":  ""jazo""
    },
    {
        ""English"":  ""an unnoticed and uncalled-for erection"",
        ""Dothraki"":  ""fitteya""
    },
    {
        ""English"":  ""ancestor"",
        ""Dothraki"":  ""kim""
    },
    {
        ""English"":  ""ancestry"",
        ""Dothraki"":  ""kimisir""
    },
    {
        ""English"":  ""and"",
        ""Dothraki"":  ""majin""
    },
    {
        ""English"":  ""animal carcass"",
        ""Dothraki"":  ""dozgikh""
    },
    {
        ""English"":  ""animal"",
        ""Dothraki"":  ""rhoa""
    },
    {
        ""English"":  ""animate noun"",
        ""Dothraki"":  ""vekhikh asavva""
    },
    {
        ""English"":  ""ankle"",
        ""Dothraki"":  ""hlofa""
    },
    {
        ""English"":  ""announcement"",
        ""Dothraki"":  ""annese""
    },
    {
        ""English"":  ""another"",
        ""Dothraki"":  ""eshna""
    },
    {
        ""English"":  ""anxious"",
        ""Dothraki"":  ""manimven""
    },
    {
        ""English"":  ""anxiousness"",
        ""Dothraki"":  ""athmanimvenar""
    },
    {
        ""English"":  ""any"",
        ""Dothraki"":  ""zhille""
    },
    {
        ""English"":  ""any grass-like ground cover"",
        ""Dothraki"":  ""hranna""
    },
    {
        ""English"":  ""any"",
        ""Dothraki"":  ""loy""
    },
    {
        ""English"":  ""app"",
        ""Dothraki"":  ""davrakh""
    },
    {
        ""English"":  ""apple"",
        ""Dothraki"":  ""qazer""
    },
    {
        ""English"":  ""arm"",
        ""Dothraki"":  ""qora""
    },
    {
        ""English"":  ""armor"",
        ""Dothraki"":  ""shor tawakof ""
    },
    {
        ""English"":  ""army"",
        ""Dothraki"":  ""lajasar""
    },
    {
        ""English"":  ""arrow"",
        ""Dothraki"":  ""loqam""
    },
    {
        ""English"":  ""as well"",
        ""Dothraki"":  ""akka""
    },
    {
        ""English"":  ""as"",
        ""Dothraki"":  ""ven""
    },
    {
        ""English"":  ""ashamed"",
        ""Dothraki"":  ""navvirzethay""
    },
    {
        ""English"":  ""ashes"",
        ""Dothraki"":  ""ikh""
    },
    {
        ""English"":  ""asleep"",
        ""Dothraki"":  ""remek""
    },
    {
        ""English"":  ""athlete"",
        ""Dothraki"":  ""rhaek""
    },
    {
        ""English"":  ""authentic"",
        ""Dothraki"":  ""tawak""
    },
    {
        ""English"":  ""autumn"",
        ""Dothraki"":  ""chafka""
    },
    {
        ""English"":  ""baby"",
        ""Dothraki"":  ""enta""
    },
    {
        ""English"":  ""back"",
        ""Dothraki"":  ""irge""
    },
    {
        ""English"":  ""bad"",
        ""Dothraki"":  ""mel""
    },
    {
        ""English"":  ""ball"",
        ""Dothraki"":  ""firi""
    },
    {
        ""English"":  ""bank"",
        ""Dothraki"":  ""ejakh""
    },
    {
        ""English"":  ""bark"",
        ""Dothraki"":  ""dishah""
    },
    {
        ""English"":  ""basket"",
        ""Dothraki"":  ""qeso""
    },
    {
        ""English"":  ""bass fis"",
        ""Dothraki"":  ""zhaqe""
    },
    {
        ""English"":  ""battle"",
        ""Dothraki"":  ""vilajero""
    },
    {
        ""English"":  ""bean"",
        ""Dothraki"":  ""challeya""
    },
    {
        ""English"":  ""bear"",
        ""Dothraki"":  ""hlizif""
    },
    {
        ""English"":  ""beard"",
        ""Dothraki"":  ""shirane""
    },
    {
        ""English"":  ""beast"",
        ""Dothraki"":  ""ivezho""
    },
    {
        ""English"":  ""beast"",
        ""Dothraki"":  ""rhoa""
    },
    {
        ""English"":  ""beat"",
        ""Dothraki"":  ""oqo""
    },
    {
        ""English"":  ""beautiful"",
        ""Dothraki"":  ""zheana""
    },
    {
        ""English"":  ""because"",
        ""Dothraki"":  ""hajinaan""
    },
    {
        ""English"":  ""because of"",
        ""Dothraki"":  ""ki""
    },
    {
        ""English"":  ""bee"",
        ""Dothraki"":  ""giz""
    },
    {
        ""English"":  ""beef"",
        ""Dothraki"":  ""dalfe""
    },
    {
        ""English"":  ""beet"",
        ""Dothraki"":  ""chot""
    },
    {
        ""English"":  ""beet paste"",
        ""Dothraki"":  ""chotteya""
    },
    {
        ""English"":  ""beetle"",
        ""Dothraki"":  ""inte""
    },
    {
        ""English"":  ""before"",
        ""Dothraki"":  ""hatif""
    },
    {
        ""English"":  ""beginner"",
        ""Dothraki"":  ""navik""
    },
    {
        ""English"":  ""bell"",
        ""Dothraki"":  ""ayena""
    },
    {
        ""English"":  ""belly"",
        ""Dothraki"":  ""gango""
    },
    {
        ""English"":  ""belt"",
        ""Dothraki"":  ""imo""
    },
    {
        ""English"":  ""big"",
        ""Dothraki"":  ""zhokwa""
    },
    {
        ""English"":  ""bird"",
        ""Dothraki"":  ""zir""
    },
    {
        ""English"":  ""bird call"",
        ""Dothraki"":  ""memziri""
    },
    {
        ""English"":  ""bird of prey"",
        ""Dothraki"":  ""zirqoyi""
    },
    {
        ""English"":  ""birth"",
        ""Dothraki"":  ""athyolar""
    },
    {
        ""English"":  ""birthday"",
        ""Dothraki"":  ""asshekhqoyi""
    },
    {
        ""English"":  ""bite"",
        ""Dothraki"":  ""osto""
    },
    {
        ""English"":  ""black"",
        ""Dothraki"":  ""kazga""
    },
    {
        ""English"":  ""black stork"",
        ""Dothraki"":  ""qana""
    },
    {
        ""English"":  ""blade"",
        ""Dothraki"":  ""az""
    },
    {
        ""English"":  ""bladed writing"",
        ""Dothraki"":  ""lirisirazo""
    },
    {
        ""English"":  ""blanket"",
        ""Dothraki"":  ""janha""
    },
    {
        ""English"":  ""bleeding"",
        ""Dothraki"":  ""qiya""
    },
    {
        ""English"":  ""blemish"",
        ""Dothraki"":  ""koge""
    },
    {
        ""English"":  ""blessing"",
        ""Dothraki"":  ""azhasavva""
    },
    {
        ""English"":  ""block"",
        ""Dothraki"":  ""jazo""
    },
    {
        ""English"":  ""blood"",
        ""Dothraki"":  ""qoy""
    },
    {
        ""English"":  ""blood of my blood"",
        ""Dothraki"":  ""qoyqoyi""
    },
    {
        ""English"":  ""blood sausage"",
        ""Dothraki"":  ""ninthqoyi""
    },
    {
        ""English"":  ""bloodrider"",
        ""Dothraki"":  ""dothrakhqoyi""
    },
    {
        ""English"":  ""bloodriders"",
        ""Dothraki"":  ""khasar""
    },
    {
        ""English"":  ""blowhard"",
        ""Dothraki"":  ""esittesak""
    },
    {
        ""English"":  ""blue"",
        ""Dothraki"":  ""thelis""
    },
    {
        ""English"":  ""boar"",
        ""Dothraki"":  ""qifo""
    },
    {
        ""English"":  ""body"",
        ""Dothraki"":  ""khado""
    },
    {
        ""English"":  ""bodyguard"",
        ""Dothraki"":  ""ko""
    },
    {
        ""English"":  ""bolas"",
        ""Dothraki"":  ""gehqoyi""
    },
    {
        ""English"":  ""bone"",
        ""Dothraki"":  ""tolorro""
    },
    {
        ""English"":  ""book"",
        ""Dothraki"":  ""timvir""
    },
    {
        ""English"":  ""boot"",
        ""Dothraki"":  ""tim""
    },
    {
        ""English"":  ""born"",
        ""Dothraki"":  ""yol""
    },
    {
        ""English"":  ""both"",
        ""Dothraki"":  ""akkate""
    },
    {
        ""English"":  ""bow"",
        ""Dothraki"":  ""kohol""
    },
    {
        ""English"":  ""box"",
        ""Dothraki"":  ""khogari""
    },
    {
        ""English"":  ""boy"",
        ""Dothraki"":  ""rakh""
    },
    {
        ""English"":  ""braggart"",
        ""Dothraki"":  ""esittesak""
    },
    {
        ""English"":  ""braidless"",
        ""Dothraki"":  ""jahakmen""
    },
    {
        ""English"":  ""brain"",
        ""Dothraki"":  ""yothnhare""
    },
    {
        ""English"":  ""bread"",
        ""Dothraki"":  ""havon""
    },
    {
        ""English"":  ""breast"",
        ""Dothraki"":  ""odaya""
    },
    {
        ""English"":  ""breed of horse with reddish or brown coat"",
        ""Dothraki"":  ""tehin""
    },
    {
        ""English"":  ""breeze"",
        ""Dothraki"":  ""gillo""
    },
    {
        ""English"":  ""bridge"",
        ""Dothraki"":  ""osoleth""
    },
    {
        ""English"":  ""bright"",
        ""Dothraki"":  ""rahsan""
    },
    {
        ""English"":  ""brittle"",
        ""Dothraki"":  ""ithkoil""
    },
    {
        ""English"":  ""broken"",
        ""Dothraki"":  ""samva""
    },
    {
        ""English"":  ""brother"",
        ""Dothraki"":  ""gaezo""
    },
    {
        ""English"":  ""brown skinned"",
        ""Dothraki"":  ""nozhoven""
    },
    {
        ""English"":  ""bubble"",
        ""Dothraki"":  ""rich""
    },
    {
        ""English"":  ""bucket"",
        ""Dothraki"":  ""igge""
    },
    {
        ""English"":  ""can"",
        ""Dothraki"":  ""laz""
    },
    {
        ""English"":  ""caravan"",
        ""Dothraki"":  ""verakasar""
    },
    {
        ""English"":  ""carelessly"",
        ""Dothraki"":  ""aranne""
    },
    {
        ""English"":  ""carrot"",
        ""Dothraki"":  ""feso""
    },
    {
        ""English"":  ""cart"",
        ""Dothraki"":  ""rhaggat""
    },
    {
        ""English"":  ""cask"",
        ""Dothraki"":  ""khogari""
    },
    {
        ""English"":  ""cat"",
        ""Dothraki"":  ""havzi""
    },
    {
        ""English"":  ""category"",
        ""Dothraki"":  ""veneser""
    },
    {
        ""English"":  ""category"",
        ""Dothraki"":  ""saccheya""
    },
    {
        ""English"":  ""caterpillar"",
        ""Dothraki"":  ""filki""
    },
    {
        ""English"":  ""certainly"",
        ""Dothraki"":  ""sekosshi""
    },
    {
        ""English"":  ""certainty"",
        ""Dothraki"":  ""athgoshar""
    },
    {
        ""English"":  ""chair"",
        ""Dothraki"":  ""ador""
    },
    {
        ""English"":  ""chatterbox"",
        ""Dothraki"":  ""fredrik""
    },
    {
        ""English"":  ""cheek"",
        ""Dothraki"":  ""dech""
    },
    {
        ""English"":  ""cheese"",
        ""Dothraki"":  ""jelli""
    },
    {
        ""English"":  ""chest"",
        ""Dothraki"":  ""khogari""
    },
    {
        ""English"":  ""chestnut horse"",
        ""Dothraki"":  ""nozho""
    },
    {
        ""English"":  ""chicken"",
        ""Dothraki"":  ""jiz""
    },
    {
        ""English"":  ""child"",
        ""Dothraki"":  ""yalli""
    },
    {
        ""English"":  ""child in the womb"",
        ""Dothraki"":  ""loshat""
    },
    {
        ""English"":  ""chin"",
        ""Dothraki"":  ""vik""
    },
    {
        ""English"":  ""chop"",
        ""Dothraki"":  ""tavat""
    },
    {
        ""English"":  ""circle"",
        ""Dothraki"":  ""fire""
    },
    {
        ""English"":  ""city"",
        ""Dothraki"":  ""vaes""
    },
    {
        ""English"":  ""class"",
        ""Dothraki"":  ""veneser""
    },
    {
        ""English"":  ""clearing in a forest"",
        ""Dothraki"":  ""dana""
    },
    {
        ""English"":  ""clenched thing"",
        ""Dothraki"":  ""himo""
    },
    {
        ""English"":  ""climate"",
        ""Dothraki"":  ""chafasar""
    },
    {
        ""English"":  ""close"",
        ""Dothraki"":  ""qisi""
    },
    {
        ""English"":  ""closed"",
        ""Dothraki"":  ""jon""
    },
    {
        ""English"":  ""clothes"",
        ""Dothraki"":  ""qemmosor""
    },
    {
        ""English"":  ""cloud"",
        ""Dothraki"":  ""fas""
    },
    {
        ""English"":  ""cold"",
        ""Dothraki"":  ""fish""
    },
    {
        ""English"":  ""collapse"",
        ""Dothraki"":  ""athohharar""
    },
    {
        ""English"":  ""collection"",
        ""Dothraki"":  ""yanqokh""
    },
    {
        ""English"":  ""color"",
        ""Dothraki"":  ""vishiya""
    },
    {
        ""English"":  ""comet"",
        ""Dothraki"":  ""shierak qiya""
    },
    {
        ""English"":  ""comfort"",
        ""Dothraki"":  ""athdisizar""
    },
    {
        ""English"":  ""command"",
        ""Dothraki"":  ""ase""
    },
    {
        ""English"":  ""company"",
        ""Dothraki"":  ""jerakasar""
    },
    {
        ""English"":  ""completely"",
        ""Dothraki"":  ""norethaan""
    },
    {
        ""English"":  ""complex"",
        ""Dothraki"":  ""nrojat""
    },
    {
        ""English"":  ""concerning"",
        ""Dothraki"":  ""qisi""
    },
    {
        ""English"":  ""conjoined"",
        ""Dothraki"":  ""kem""
    },
    {
        ""English"":  ""consequently"",
        ""Dothraki"":  ""majin""
    },
    {
        ""English"":  ""constructed language"",
        ""Dothraki"":  ""lekhmove""
    },
    {
        ""English"":  ""cooking pot"",
        ""Dothraki"":  ""jolino""
    },
    {
        ""English"":  ""corn"",
        ""Dothraki"":  ""jorok""
    },
    {
        ""English"":  ""corn bunting"",
        ""Dothraki"":  ""faqqi""
    },
    {
        ""English"":  ""corpse"",
        ""Dothraki"":  ""khadokh""
    },
    {
        ""English"":  ""correctness"",
        ""Dothraki"":  ""athjilar""
    },
    {
        ""English"":  ""could"",
        ""Dothraki"":  ""laz""
    },
    {
        ""English"":  ""council"",
        ""Dothraki"":  ""dosh""
    },
    {
        ""English"":  ""country"",
        ""Dothraki"":  ""rhaesh""
    },
    {
        ""English"":  ""cover"",
        ""Dothraki"":  ""qemmo""
    },
    {
        ""English"":  ""cow"",
        ""Dothraki"":  ""dalfe""
    },
    {
        ""English"":  ""coward"",
        ""Dothraki"":  ""aresak""
    },
    {
        ""English"":  ""cranberry"",
        ""Dothraki"":  ""asfavirzeth""
    },
    {
        ""English"":  ""crazy"",
        ""Dothraki"":  ""yofi""
    },
    {
        ""English"":  ""cream"",
        ""Dothraki"":  ""flas""
    },
    {
        ""English"":  ""cricket"",
        ""Dothraki"":  ""chifti""
    },
    {
        ""English"":  ""cricket man"",
        ""Dothraki"":  ""chiftik(used as an insult)""
    },
    {
        ""English"":  ""crone"",
        ""Dothraki"":  ""yesi""
    },
    {
        ""English"":  ""crossing"",
        ""Dothraki"":  ""yom""
    },
    {
        ""English"":  ""crown"",
        ""Dothraki"":  ""firikhnharen""
    },
    {
        ""English"":  ""curved sword"",
        ""Dothraki"":  ""arakh""
    },
    {
        ""English"":  ""dagger"",
        ""Dothraki"":  ""mihesof""
    },
    {
        ""English"":  ""dancing"",
        ""Dothraki"":  ""athezhirar""
    },
    {
        ""English"":  ""dancing"",
        ""Dothraki"":  ""ezhiray""
    },
    {
        ""English"":  ""danger"",
        ""Dothraki"":  ""athzhowakar""
    },
    {
        ""English"":  ""dangerous"",
        ""Dothraki"":  ""zhowak""
    },
    {
        ""English"":  ""dappled horse"",
        ""Dothraki"":  ""fansa""
    },
    {
        ""English"":  ""dark (of color)"",
        ""Dothraki"":  ""ao""
    },
    {
        ""English"":  ""dark bay horse"",
        ""Dothraki"":  ""cheyao""
    },
    {
        ""English"":  ""dark brown skinned"",
        ""Dothraki"":  ""cheyaoven""
    },
    {
        ""English"":  ""date"",
        ""Dothraki"":  ""kimikh(fruit of a date palm)""
    },
    {
        ""English"":  ""daughter"",
        ""Dothraki"":  ""ohara""
    },
    {
        ""English"":  ""daughter of a khal"",
        ""Dothraki"":  ""khalakki""
    },
    {
        ""English"":  ""day"",
        ""Dothraki"":  ""asshekh""
    },
    {
        ""English"":  ""dead"",
        ""Dothraki"":  ""driv""
    },
    {
        ""English"":  ""death"",
        ""Dothraki"":  ""athdrivar""
    },
    {
        ""English"":  ""deception"",
        ""Dothraki"":  ""qosarvenikh""
    },
    {
        ""English"":  ""deceptive"",
        ""Dothraki"":  ""qosarven""
    },
    {
        ""English"":  ""deed"",
        ""Dothraki"":  ""tikh""
    },
    {
        ""English"":  ""deep"",
        ""Dothraki"":  ""ao""
    },
    {
        ""English"":  ""deep"",
        ""Dothraki"":  ""athaozar""
    },
    {
        ""English"":  ""deer"",
        ""Dothraki"":  ""qlaseh""
    },
    {
        ""English"":  ""Default preposition for foreign words thet do not decline"",
        ""Dothraki"":  ""haji""
    },
    {
        ""English"":  ""defeat"",
        ""Dothraki"":  ""athohharar""
    },
    {
        ""English"":  ""deity"",
        ""Dothraki"":  ""vojjor""
    },
    {
        ""English"":  ""departure"",
        ""Dothraki"":  ""athezar""
    },
    {
        ""English"":  ""depths"",
        ""Dothraki"":  ""athaozar""
    },
    {
        ""English"":  ""destination"",
        ""Dothraki"":  ""ovvethikh""
    },
    {
        ""English"":  ""destiny"",
        ""Dothraki"":  ""fasqoyi""
    },
    {
        ""English"":  ""did you know?"",
        ""Dothraki"":  ""hash yer ray nesi""
    },
    {
        ""English"":  ""different"",
        ""Dothraki"":  ""esina""
    },
    {
        ""English"":  ""dirt"",
        ""Dothraki"":  ""sorfo""
    },
    {
        ""English"":  ""dirty"",
        ""Dothraki"":  ""sorf""
    },
    {
        ""English"":  ""disappointed"",
        ""Dothraki"":  ""lost""
    },
    {
        ""English"":  ""discussion"",
        ""Dothraki"":  ""ni athjerizar""
    },
    {
        ""English"":  ""disrespectful"",
        ""Dothraki"":  ""zichome""
    },
    {
        ""English"":  ""distance traveled in one leshitof"",
        ""Dothraki"":  ""karlina""
    },
    {
        ""English"":  ""do"",
        ""Dothraki"":  ""hash""
    },
    {
        ""English"":  ""dog"",
        ""Dothraki"":  ""jano""
    },
    {
        ""English"":  ""Dothraki"",
        ""Dothraki"":  ""lekh dothraki(language)""
    },
    {
        ""English"":  ""Dothraki hair-braid"",
        ""Dothraki"":  ""jahak""
    },
    {
        ""English"":  ""down"",
        ""Dothraki"":  ""zohhe""
    },
    {
        ""English"":  ""downward"",
        ""Dothraki"":  ""zohhe""
    },
    {
        ""English"":  ""downwards"",
        ""Dothraki"":  ""zohhe""
    },
    {
        ""English"":  ""dragon"",
        ""Dothraki"":  ""zhavorsa""
    },
    {
        ""English"":  ""dragon glass"",
        ""Dothraki"":  ""sondra""
    },
    {
        ""English"":  ""dream"",
        ""Dothraki"":  ""atthirarido""
    },
    {
        ""English"":  ""dress"",
        ""Dothraki"":  ""shor""
    },
    {
        ""English"":  ""dried fig"",
        ""Dothraki"":  ""kemis""
    },
    {
        ""English"":  ""dried plum"",
        ""Dothraki"":  ""filla""
    },
    {
        ""English"":  ""dried salted meat"",
        ""Dothraki"":  ""zhifikh""
    },
    {
        ""English"":  ""dry"",
        ""Dothraki"":  ""ath""
    },
    {
        ""English"":  ""duck"",
        ""Dothraki"":  ""alegra""
    },
    {
        ""English"":  ""dull"",
        ""Dothraki"":  ""flech""
    },
    {
        ""English"":  ""dumb"",
        ""Dothraki"":  ""toki""
    },
    {
        ""English"":  ""dun horse"",
        ""Dothraki"":  ""ocha""
    },
    {
        ""English"":  ""during"",
        ""Dothraki"":  ""kash""
    },
    {
        ""English"":  ""dust"",
        ""Dothraki"":  ""vod""
    },
    {
        ""English"":  ""duty"",
        ""Dothraki"":  ""atthar""
    },
    {
        ""English"":  ""eagle"",
        ""Dothraki"":  ""kolver""
    },
    {
        ""English"":  ""ear"",
        ""Dothraki"":  ""chare""
    },
    {
        ""English"":  ""earth"",
        ""Dothraki"":  ""sorfosor(world)""
    },
    {
        ""English"":  ""earthquake"",
        ""Dothraki"":  ""vash hrazefmen""
    },
    {
        ""English"":  ""east"",
        ""Dothraki"":  ""titha""
    },
    {
        ""English"":  ""eastern"",
        ""Dothraki"":  ""tith""
    },
    {
        ""English"":  ""eating spree for a special taste"",
        ""Dothraki"":  ""lanlekhi""
    },
    {
        ""English"":  ""egg"",
        ""Dothraki"":  ""gale""
    },
    {
        ""English"":  ""eight"",
        ""Dothraki"":  ""ori""
    },
    {
        ""English"":  ""eight hundred"",
        ""Dothraki"":  ""oriken""
    },
    {
        ""English"":  ""eighteen"",
        ""Dothraki"":  ""oritthi""
    },
    {
        ""English"":  ""eighth"",
        ""Dothraki"":  ""orik""
    },
    {
        ""English"":  ""eighty"",
        ""Dothraki"":  ""chori""
    },
    {
        ""English"":  ""either"",
        ""Dothraki"":  ""che""
    },
    {
        ""English"":  ""elbow"",
        ""Dothraki"":  ""vem""
    },
    {
        ""English"":  ""elder"",
        ""Dothraki"":  ""fozak""
    },
    {
        ""English"":  ""eleven"",
        ""Dothraki"":  ""atthi""
    },
    {
        ""English"":  ""emphatic negative"",
        ""Dothraki"":  ""vosecchi""
    },
    {
        ""English"":  ""end"",
        ""Dothraki"":  ""nakho""
    },
    {
        ""English"":  ""enemy"",
        ""Dothraki"":  ""dozgo""
    },
    {
        ""English"":  ""enemy horde"",
        ""Dothraki"":  ""dozgosor""
    },
    {
        ""English"":  ""enormous"",
        ""Dothraki"":  ""zhokakkwa""
    },
    {
        ""English"":  ""enough"",
        ""Dothraki"":  ""lekhaan""
    },
    {
        ""English"":  ""environs"",
        ""Dothraki"":  ""gache""
    },
    {
        ""English"":  ""even so"",
        ""Dothraki"":  ""akka""
    },
    {
        ""English"":  ""every"",
        ""Dothraki"":  ""ei""
    },
    {
        ""English"":  ""everyone"",
        ""Dothraki"":  ""eyak""
    },
    {
        ""English"":  ""evil"",
        ""Dothraki"":  ""mel""
    },
    {
        ""English"":  ""excellent"",
        ""Dothraki"":  ""athvezhvenar""
    },
    {
        ""English"":  ""excellently"",
        ""Dothraki"":  ""chekosshi""
    },
    {
        ""English"":  ""exclusively"",
        ""Dothraki"":  ""disse""
    },
    {
        ""English"":  ""executioner"",
        ""Dothraki"":  ""jaqqa""
    },
    {
        ""English"":  ""exhausted"",
        ""Dothraki"":  ""haqeqqe""
    },
    {
        ""English"":  ""exit"",
        ""Dothraki"":  ""esemrasakh""
    },
    {
        ""English"":  ""extreme"",
        ""Dothraki"":  """"
    },
    {
        ""English"":  ""eye"",
        ""Dothraki"":  ""tih""
    },
    {
        ""English"":  ""eye healer"",
        ""Dothraki"":  ""koalakhtihan""
    },
    {
        ""English"":  ""eyelid"",
        ""Dothraki"":  ""qemmotihan""
    },
    {
        ""English"":  ""face"",
        ""Dothraki"":  ""hatif""
    },
    {
        ""English"":  ""failure"",
        ""Dothraki"":  ""yeni""
    },
    {
        ""English"":  ""fake"",
        ""Dothraki"":  ""ido""
    },
    {
        ""English"":  ""family"",
        ""Dothraki"":  ""rhojosor""
    },
    {
        ""English"":  ""famous"",
        ""Dothraki"":  ""hakeso""
    },
    {
        ""English"":  ""far"",
        ""Dothraki"":  ""hezhah""
    },
    {
        ""English"":  ""farther"",
        ""Dothraki"":  ""alle""
    },
    {
        ""English"":  ""fast"",
        ""Dothraki"":  ""dik""
    },
    {
        ""English"":  ""fat"",
        ""Dothraki"":  ""oiro""
    },
    {
        ""English"":  ""fat"",
        ""Dothraki"":  ""ovah""
    },
    {
        ""English"":  ""fatality"",
        ""Dothraki"":  ""athaddrivar""
    },
    {
        ""English"":  ""father"",
        ""Dothraki"":  ""ave""
    },
    {
        ""English"":  ""fear"",
        ""Dothraki"":  ""athrokhar""
    },
    {
        ""English"":  ""feast day"",
        ""Dothraki"":  ""vitteyqoyi""
    },
    {
        ""English"":  ""feast"",
        ""Dothraki"":  ""vitteya""
    },
    {
        ""English"":  ""feather"",
        ""Dothraki"":  ""feldekh""
    },
    {
        ""English"":  ""female dog"",
        ""Dothraki"":  ""nhomi""
    },
    {
        ""English"":  ""female goat"",
        ""Dothraki"":  ""jin""
    },
    {
        ""English"":  ""female healer"",
        ""Dothraki"":  ""koalakeesi""
    },
    {
        ""English"":  ""female relative"",
        ""Dothraki"":  ""krista""
    },
    {
        ""English"":  ""fermented"",
        ""Dothraki"":  ""ohazho""
    },
    {
        ""English"":  ""fermented mare’s milk"",
        ""Dothraki"":  ""lamekh ohazho""
    },
    {
        ""English"":  ""few"",
        ""Dothraki"":  ""loy""
    },
    {
        ""English"":  ""fifteen"",
        ""Dothraki"":  ""mekthi""
    },
    {
        ""English"":  ""fifth"",
        ""Dothraki"":  ""mekak""
    },
    {
        ""English"":  ""fifty"",
        ""Dothraki"":  ""chimek""
    },
    {
        ""English"":  ""fig"",
        ""Dothraki"":  ""zhorrof""
    },
    {
        ""English"":  ""fighter"",
        ""Dothraki"":  ""lajak""
    },
    {
        ""English"":  ""filly"",
        ""Dothraki"":  ""vado""
    },
    {
        ""English"":  ""finally"",
        ""Dothraki"":  ""ha nakhaan""
    },
    {
        ""English"":  ""finger"",
        ""Dothraki"":  ""tir""
    },
    {
        ""English"":  ""fire"",
        ""Dothraki"":  ""vorsa""
    },
    {
        ""English"":  ""firefly"",
        ""Dothraki"":  ""qacha""
    },
    {
        ""English"":  ""firey"",
        ""Dothraki"":  ""ozzirven""
    },
    {
        ""English"":  ""first"",
        ""Dothraki"":  ""ataki""
    },
    {
        ""English"":  ""first"",
        ""Dothraki"":  ""ate""
    },
    {
        ""English"":  ""firstly"",
        ""Dothraki"":  ""atte""
    },
    {
        ""English"":  ""fish"",
        ""Dothraki"":  ""eshina""
    },
    {
        ""English"":  ""fist"",
        ""Dothraki"":  ""himo""
    },
    {
        ""English"":  ""five"",
        ""Dothraki"":  ""mek""
    },
    {
        ""English"":  ""five hundred"",
        ""Dothraki"":  ""mekken""
    },
    {
        ""English"":  ""fizzle out"",
        ""Dothraki"":  ""shinat""
    },
    {
        ""English"":  ""flag"",
        ""Dothraki"":  ""khiro""
    },
    {
        ""English"":  ""flame"",
        ""Dothraki"":  ""vorsakh""
    },
    {
        ""English"":  ""flash"",
        ""Dothraki"":  ""dili""
    },
    {
        ""English"":  ""flashing"",
        ""Dothraki"":  ""ozzirven""
    },
    {
        ""English"":  ""flaw"",
        ""Dothraki"":  ""koge""
    },
    {
        ""English"":  ""flawless"",
        ""Dothraki"":  ""kogmen""
    },
    {
        ""English"":  ""flea"",
        ""Dothraki"":  ""krol""
    },
    {
        ""English"":  ""flesh"",
        ""Dothraki"":  ""kher""
    },
    {
        ""English"":  ""flower"",
        ""Dothraki"":  ""halah""
    },
    {
        ""English"":  ""fly"",
        ""Dothraki"":  ""afis""
    },
    {
        ""English"":  ""foal"",
        ""Dothraki"":  ""nerro""
    },
    {
        ""English"":  ""fog"",
        ""Dothraki"":  ""devesh""
    },
    {
        ""English"":  ""follower"",
        ""Dothraki"":  ""silak""
    },
    {
        ""English"":  ""food"",
        ""Dothraki"":  ""hadaen""
    },
    {
        ""English"":  ""fool"",
        ""Dothraki"":  ""tokik""
    },
    {
        ""English"":  ""foot"",
        ""Dothraki"":  ""rhae""
    },
    {
        ""English"":  ""for"",
        ""Dothraki"":  ""ha""
    },
    {
        ""English"":  ""forbidden"",
        ""Dothraki"":  ""izven""
    },
    {
        ""English"":  ""ford"",
        ""Dothraki"":  ""dan""
    },
    {
        ""English"":  ""forearm"",
        ""Dothraki"":  ""ni qorraya""
    },
    {
        ""English"":  ""forehead"",
        ""Dothraki"":  ""vish""
    },
    {
        ""English"":  ""foreigner"",
        ""Dothraki"":  ""ifak""
    },
    {
        ""English"":  ""forest"",
        ""Dothraki"":  ""qevir""
    },
    {
        ""English"":  ""forty"",
        ""Dothraki"":  ""chitor""
    },
    {
        ""English"":  ""four"",
        ""Dothraki"":  ""tor""
    },
    {
        ""English"":  ""four hundred"",
        ""Dothraki"":  ""torken""
    },
    {
        ""English"":  ""fourteen"",
        ""Dothraki"":  ""torthi""
    },
    {
        ""English"":  ""fourth"",
        ""Dothraki"":  ""torak""
    },
    {
        ""English"":  ""fox"",
        ""Dothraki"":  ""jith""
    },
    {
        ""English"":  ""free"",
        ""Dothraki"":  ""seris""
    },
    {
        ""English"":  ""freeze"",
        ""Dothraki"":  ""jesholat""
    },
    {
        ""English"":  ""freezing"",
        ""Dothraki"":  ""jeshoy""
    },
    {
        ""English"":  ""fresh"",
        ""Dothraki"":  ""chosh""
    },
    {
        ""English"":  ""friend"",
        ""Dothraki"":  ""okeo""
    },
    {
        ""English"":  ""frog"",
        ""Dothraki"":  ""yetto""
    },
    {
        ""English"":  ""from"",
        ""Dothraki"":  ""ha""
    },
    {
        ""English"":  ""from before"",
        ""Dothraki"":  ""hatif""
    },
    {
        ""English"":  ""from behind"",
        ""Dothraki"":  ""irge""
    },
    {
        ""English"":  ""from front of"",
        ""Dothraki"":  ""hatif""
    },
    {
        ""English"":  ""from since"",
        ""Dothraki"":  ""arrekoon""
    },
    {
        ""English"":  ""from the beginning"",
        ""Dothraki"":  ""evoon""
    },
    {
        ""English"":  ""from where"",
        ""Dothraki"":  ""rekkoon""
    },
    {
        ""English"":  ""frozen"",
        ""Dothraki"":  ""jesho""
    },
    {
        ""English"":  ""fruit"",
        ""Dothraki"":  ""yot""
    },
    {
        ""English"":  ""frustration"",
        ""Dothraki"":  ""athahhaqar""
    },
    {
        ""English"":  ""fucker"",
        ""Dothraki"":  ""govak""
    },
    {
        ""English"":  ""fully"",
        ""Dothraki"":  ""nakhaan""
    },
    {
        ""English"":  ""funeral pyre"",
        ""Dothraki"":  ""vorsqoyi""
    },
    {
        ""English"":  ""fur"",
        ""Dothraki"":  ""hem""
    },
    {
        ""English"":  ""furry"",
        ""Dothraki"":  ""heme""
    },
    {
        ""English"":  ""further"",
        ""Dothraki"":  ""alle""
    },
    {
        ""English"":  ""fury"",
        ""Dothraki"":  ""athostar""
    },
    {
        ""English"":  ""game"",
        ""Dothraki"":  ""vilajerosh""
    },
    {
        ""English"":  ""garlic"",
        ""Dothraki"":  ""mredi""
    },
    {
        ""English"":  ""gate"",
        ""Dothraki"":  ""emrakh""
    },
    {
        ""English"":  ""gathering with a feast"",
        ""Dothraki"":  ""vitteya""
    },
    {
        ""English"":  ""gem"",
        ""Dothraki"":  ""dan""
    },
    {
        ""English"":  ""general"",
        ""Dothraki"":  ""zhilli""
    },
    {
        ""English"":  ""generals"",
        ""Dothraki"":  ""khasar""
    },
    {
        ""English"":  ""ghost"",
        ""Dothraki"":  ""lei""
    },
    {
        ""English"":  ""giddyup"",
        ""Dothraki"":  ""hosh(horse command)""
    },
    {
        ""English"":  ""gift"",
        ""Dothraki"":  ""azho""
    },
    {
        ""English"":  ""girl"",
        ""Dothraki"":  ""nayat""
    },
    {
        ""English"":  ""glancing blow"",
        ""Dothraki"":  ""chiftikh""
    },
    {
        ""English"":  ""glove"",
        ""Dothraki"":  ""hlaka""
    },
    {
        ""English"":  ""Go"",
        ""Dothraki"":  ""gwe""
    },
    {
        ""English"":  ""goal"",
        ""Dothraki"":  ""ovvethikh""
    },
    {
        ""English"":  ""goat"",
        ""Dothraki"":  ""dorvi""
    },
    {
        ""English"":  ""god"",
        ""Dothraki"":  ""vojjor""
    },
    {
        ""English"":  ""golden"",
        ""Dothraki"":  ""hoshor""
    },
    {
        ""English"":  ""good"",
        ""Dothraki"":  ""erin""
    },
    {
        ""English"":  ""gossip"",
        ""Dothraki"":  ""shilak""
    },
    {
        ""English"":  ""grandfather"",
        ""Dothraki"":  ""simonof""
    },
    {
        ""English"":  ""grandmother"",
        ""Dothraki"":  ""kristasof""
    },
    {
        ""English"":  ""grape"",
        ""Dothraki"":  ""sewaf""
    },
    {
        ""English"":  ""gray"",
        ""Dothraki"":  ""shiqeth""
    },
    {
        ""English"":  ""great"",
        ""Dothraki"":  ""vezhven""
    },
    {
        ""English"":  ""greatness"",
        ""Dothraki"":  ""athvezhvenar""
    },
    {
        ""English"":  ""green"",
        ""Dothraki"":  ""dahaan""
    },
    {
        ""English"":  ""greens"",
        ""Dothraki"":  ""ilmeser""
    },
    {
        ""English"":  ""guard"",
        ""Dothraki"":  ""loshak""
    },
    {
        ""English"":  ""guard"",
        ""Dothraki"":  ""vitihirak""
    },
    {
        ""English"":  ""guest"",
        ""Dothraki"":  ""nevak""
    },
    {
        ""English"":  ""gust of wind"",
        ""Dothraki"":  ""hador""
    },
    {
        ""English"":  ""hair"",
        ""Dothraki"":  ""noreth""
    },
    {
        ""English"":  ""hairstyle"",
        ""Dothraki"":  ""jahak""
    },
    {
        ""English"":  ""half"",
        ""Dothraki"":  ""sachi""
    },
    {
        ""English"":  ""halt"",
        ""Dothraki"":  ""soroh(horse command)""
    },
    {
        ""English"":  ""hand"",
        ""Dothraki"":  ""qora""
    },
    {
        ""English"":  ""handmaid"",
        ""Dothraki"":  ""khaleessiya""
    },
    {
        ""English"":  ""harvest moon"",
        ""Dothraki"":  ""jalan qoyi""
    },
    {
        ""English"":  ""have to"",
        ""Dothraki"":  ""eth""
    },
    {
        ""English"":  ""he"",
        ""Dothraki"":  ""me""
    },
    {
        ""English"":  ""head"",
        ""Dothraki"":  ""nhare""
    },
    {
        ""English"":  ""headache"",
        ""Dothraki"":  ""mhari""
    },
    {
        ""English"":  ""healer"",
        ""Dothraki"":  ""koalak""
    },
    {
        ""English"":  ""heap"",
        ""Dothraki"":  ""san""
    },
    {
        ""English"":  ""heart"",
        ""Dothraki"":  ""zhor""
    },
    {
        ""English"":  ""heartbeat"",
        ""Dothraki"":  ""oqooqo""
    },
    {
        ""English"":  ""heavy"",
        ""Dothraki"":  ""ohazh""
    },
    {
        ""English"":  ""heel of a boot"",
        ""Dothraki"":  ""vemishikh""
    },
    {
        ""English"":  ""heel of the hand or foot"",
        ""Dothraki"":  ""vemish""
    },
    {
        ""English"":  ""help"",
        ""Dothraki"":  ""rhellaya""
    },
    {
        ""English"":  ""hemp"",
        ""Dothraki"":  ""ferri""
    },
    {
        ""English"":  ""hence"",
        ""Dothraki"":  ""hezhah""
    },
    {
        ""English"":  ""her"",
        ""Dothraki"":  ""mae""
    },
    {
        ""English"":  ""hers"",
        ""Dothraki"":  ""mae""
    },
    {
        ""English"":  ""herd"",
        ""Dothraki"":  ""drogikh""
    },
    {
        ""English"":  ""herd of wild horses"",
        ""Dothraki"":  ""hrazefeser""
    },
    {
        ""English"":  ""here"",
        ""Dothraki"":  ""jinne""
    },
    {
        ""English"":  ""Here"",
        ""Dothraki"":  ""gwe""
    },
    {
        ""English"":  ""hey"",
        ""Dothraki"":  ""hale""
    },
    {
        ""English"":  ""hi"",
        ""Dothraki"":  ""m’ath""
    },
    {
        ""English"":  ""high"",
        ""Dothraki"":  ""yath""
    },
    {
        ""English"":  ""hill"",
        ""Dothraki"":  ""olta""
    },
    {
        ""English"":  ""him"",
        ""Dothraki"":  ""mae""
    },
    {
        ""English"":  ""his"",
        ""Dothraki"":  ""mae""
    },
    {
        ""English"":  ""hollow"",
        ""Dothraki"":  ""renrenoh""
    },
    {
        ""English"":  ""honey"",
        ""Dothraki"":  ""gizikh""
    },
    {
        ""English"":  ""honor"",
        ""Dothraki"":  ""chomokh""
    },
    {
        ""English"":  ""hope"",
        ""Dothraki"":  ""athzalar""
    },
    {
        ""English"":  ""horizon"",
        ""Dothraki"":  ""valad""
    },
    {
        ""English"":  ""horn"",
        ""Dothraki"":  ""chiva""
    },
    {
        ""English"":  ""horse"",
        ""Dothraki"":  ""hrazef""
    },
    {
        ""English"":  ""horse lord"",
        ""Dothraki"":  ""vezhak""
    },
    {
        ""English"":  ""host"",
        ""Dothraki"":  ""idrik""
    },
    {
        ""English"":  ""hot"",
        ""Dothraki"":  ""afazh""
    },
    {
        ""English"":  ""how"",
        ""Dothraki"":  ""kifinosi""
    },
    {
        ""English"":  ""hundred"",
        ""Dothraki"":  ""ken""
    },
    {
        ""English"":  ""hundredth"",
        ""Dothraki"":  ""kenak""
    },
    {
        ""English"":  ""hurrah"",
        ""Dothraki"":  ""rai""
    },
    {
        ""English"":  ""hunter"",
        ""Dothraki"":  ""fonak""
    },
    {
        ""English"":  ""hunting party"",
        ""Dothraki"":  ""fonakasar""
    },
    {
        ""English"":  ""husband"",
        ""Dothraki"":  ""mahrazhkem""
    },
    {
        ""English"":  ""I"",
        ""Dothraki"":  ""anha""
    },
    {
        ""English"":  ""ibex"",
        ""Dothraki"":  ""dorvof""
    },
    {
        ""English"":  ""ice"",
        ""Dothraki"":  ""jesh""
    },
    {
        ""English"":  ""icon"",
        ""Dothraki"":  ""joro""
    },
    {
        ""English"":  ""icy"",
        ""Dothraki"":  ""jeshven""
    },
    {
        ""English"":  ""idea"",
        ""Dothraki"":  ""dirge""
    },
    {
        ""English"":  ""idol"",
        ""Dothraki"":  ""joro""
    },
    {
        ""English"":  ""if prolonged"",
        ""Dothraki"":  ""karlinqoyi""
    },
    {
        ""English"":  ""if"",
        ""Dothraki"":  ""hash""
    },
    {
        ""English"":  ""imperfection"",
        ""Dothraki"":  ""koge""
    },
    {
        ""English"":  ""in front of"",
        ""Dothraki"":  ""hatif""
    },
    {
        ""English"":  ""in spite of"",
        ""Dothraki"":  ""yomme""
    },
    {
        ""English"":  ""in this way"",
        ""Dothraki"":  ""kijinosi""
    },
    {
        ""English"":  ""in"",
        ""Dothraki"":  ""she""
    },
    {
        ""English"":  ""inanimate"",
        ""Dothraki"":  ""vekhikh hranna""
    },
    {
        ""English"":  ""incorrect"",
        ""Dothraki"":  ""ojil""
    },
    {
        ""English"":  ""infant"",
        ""Dothraki"":  ""enta""
    },
    {
        ""English"":  ""information"",
        ""Dothraki"":  ""nesikh""
    },
    {
        ""English"":  ""instructions"",
        ""Dothraki"":  ""assokh""
    },
    {
        ""English"":  ""intestines"",
        ""Dothraki"":  ""gaoli""
    },
    {
        ""English"":  ""into"",
        ""Dothraki"":  ""mra""
    },
    {
        ""English"":  ""introduction"",
        ""Dothraki"":  ""asshie""
    },
    {
        ""English"":  ""iron"",
        ""Dothraki"":  ""shiqethi""
    },
    {
        ""English"":  ""island"",
        ""Dothraki"":  ""qile""
    },
    {
        ""English"":  ""it’s a trap"",
        ""Dothraki"":  ""me orzo""
    },
    {
        ""English"":  ""it"",
        ""Dothraki"":  ""me""
    },
    {
        ""English"":  ""it"",
        ""Dothraki"":  ""mae""
    },
    {
        ""English"":  ""its"",
        ""Dothraki"":  ""mae""
    },
    {
        ""English"":  ""jug"",
        ""Dothraki"":  ""heffof""
    },
    {
        ""English"":  ""juice"",
        ""Dothraki"":  ""thom""
    },
    {
        ""English"":  ""juicy"",
        ""Dothraki"":  ""sathoma""
    },
    {
        ""English"":  ""just"",
        ""Dothraki"":  ""disse""
    },
    {
        ""English"":  ""kid"",
        ""Dothraki"":  ""mafo""
    },
    {
        ""English"":  ""killing spree"",
        ""Dothraki"":  ""lanqoyi""
    },
    {
        ""English"":  ""kilometer"",
        ""Dothraki"":  ""karlina Valeri""
    },
    {
        ""English"":  ""kind one"",
        ""Dothraki"":  ""erinak""
    },
    {
        ""English"":  ""kind"",
        ""Dothraki"":  ""erin""
    },
    {
        ""English"":  ""king"",
        ""Dothraki"":  ""khal""
    },
    {
        ""English"":  ""kiss"",
        ""Dothraki"":  ""zoqwa""
    },
    {
        ""English"":  ""knee"",
        ""Dothraki"":  ""vem""
    },
    {
        ""English"":  ""lack"",
        ""Dothraki"":  ""gerikh""
    },
    {
        ""English"":  ""lady"",
        ""Dothraki"":  ""erinak""
    },
    {
        ""English"":  ""lake"",
        ""Dothraki"":  ""tozara""
    },
    {
        ""English"":  ""lamb"",
        ""Dothraki"":  ""rakh""
    },
    {
        ""English"":  ""lame"",
        ""Dothraki"":  ""darin""
    },
    {
        ""English"":  ""lameness"",
        ""Dothraki"":  ""athdarinar""
    },
    {
        ""English"":  ""land"",
        ""Dothraki"":  ""ramasar""
    },
    {
        ""English"":  ""language"",
        ""Dothraki"":  ""lekh""
    },
    {
        ""English"":  ""lark"",
        ""Dothraki"":  ""kane""
    },
    {
        ""English"":  ""last"",
        ""Dothraki"":  ""ha nakhaan""
    },
    {
        ""English"":  ""lay"",
        ""Dothraki"":  ""athchilar""
    },
    {
        ""English"":  ""lazy"",
        ""Dothraki"":  ""havziven""
    },
    {
        ""English"":  ""leader"",
        ""Dothraki"":  ""akkelenak""
    },
    {
        ""English"":  ""leader of the hunt"",
        ""Dothraki"":  ""idrik""
    },
    {
        ""English"":  ""leaf"",
        ""Dothraki"":  ""daeni""
    },
    {
        ""English"":  ""learner"",
        ""Dothraki"":  ""ezok""
    },
    {
        ""English"":  ""leather"",
        ""Dothraki"":  ""kherikh""
    },
    {
        ""English"":  ""left"",
        ""Dothraki"":  ""sindarine""
    },
    {
        ""English"":  ""left side"",
        ""Dothraki"":  ""sindarinekh""
    },
    {
        ""English"":  ""leg"",
        ""Dothraki"":  ""rhae""
    },
    {
        ""English"":  ""legitimate"",
        ""Dothraki"":  ""tawak""
    },
    {
        ""English"":  ""lemon"",
        ""Dothraki"":  ""jela""
    },
    {
        ""English"":  ""Let’s go"",
        ""Dothraki"":  ""gwe""
    },
    {
        ""English"":  ""lie"",
        ""Dothraki"":  ""qosarvenikh""
    },
    {
        ""English"":  ""life"",
        ""Dothraki"":  ""atthirar""
    },
    {
        ""English"":  ""light"",
        ""Dothraki"":  ""shekhikh""
    },
    {
        ""English"":  ""light"",
        ""Dothraki"":  ""dei""
    },
    {
        ""English"":  ""light brown skinned"",
        ""Dothraki"":  ""qahlanven""
    },
    {
        ""English"":  ""light skinned"",
        ""Dothraki"":  ""ochaven""
    },
    {
        ""English"":  ""lightning"",
        ""Dothraki"":  ""sisi""
    },
    {
        ""English"":  ""like slaughtering an animal"",
        ""Dothraki"":  ""ogat""
    },
    {
        ""English"":  ""like"",
        ""Dothraki"":  ""ven""
    },
    {
        ""English"":  ""limit"",
        ""Dothraki"":  ""athchilar""
    },
    {
        ""English"":  ""limp"",
        ""Dothraki"":  ""darin""
    },
    {
        ""English"":  ""limper"",
        ""Dothraki"":  ""mattek(insult)""
    },
    {
        ""English"":  ""lion’s mane"",
        ""Dothraki"":  ""jahak""
    },
    {
        ""English"":  ""lips"",
        ""Dothraki"":  ""heth""
    },
    {
        ""English"":  ""little light"",
        ""Dothraki"":  ""shekhikhi""
    },
    {
        ""English"":  ""liver"",
        ""Dothraki"":  ""cheno""
    },
    {
        ""English"":  ""lizard"",
        ""Dothraki"":  ""zhav""
    },
    {
        ""English"":  ""locust"",
        ""Dothraki"":  ""chelsian""
    },
    {
        ""English"":  ""long"",
        ""Dothraki"":  ""neak""
    },
    {
        ""English"":  ""look"",
        ""Dothraki"":  ""athtihar""
    },
    {
        ""English"":  ""loose"",
        ""Dothraki"":  ""ovray""
    },
    {
        ""English"":  ""lost"",
        ""Dothraki"":  ""lei""
    },
    {
        ""English"":  ""loud"",
        ""Dothraki"":  ""lavakh""
    },
    {
        ""English"":  ""loudness"",
        ""Dothraki"":  ""athlavakhar""
    },
    {
        ""English"":  ""louse"",
        ""Dothraki"":  ""glen""
    },
    {
        ""English"":  ""love"",
        ""Dothraki"":  ""athzhilar""
    },
    {
        ""English"":  ""low"",
        ""Dothraki"":  ""zoh""
    },
    {
        ""English"":  ""lungs"",
        ""Dothraki"":  ""gadim""
    },
    {
        ""English"":  ""lying"",
        ""Dothraki"":  ""chilay""
    },
    {
        ""English"":  ""mad"",
        ""Dothraki"":  ""yofi""
    },
    {
        ""English"":  ""magic"",
        ""Dothraki"":  ""athmovezar""
    },
    {
        ""English"":  ""magician"",
        ""Dothraki"":  ""movek""
    },
    {
        ""English"":  ""male relative"",
        ""Dothraki"":  ""simon""
    },
    {
        ""English"":  ""man"",
        ""Dothraki"":  ""mahrazh""
    },
    {
        ""English"":  ""many times"",
        ""Dothraki"":  ""sanekhi""
    },
    {
        ""English"":  ""many"",
        ""Dothraki"":  ""san""
    },
    {
        ""English"":  ""mare"",
        ""Dothraki"":  ""lame""
    },
    {
        ""English"":  ""mare’s milk"",
        ""Dothraki"":  ""lamekh""
    },
    {
        ""English"":  ""marked"",
        ""Dothraki"":  ""shoven""
    },
    {
        ""English"":  ""market"",
        ""Dothraki"":  ""jeser""
    },
    {
        ""English"":  ""marmot"",
        ""Dothraki"":  ""thave""
    },
    {
        ""English"":  ""married"",
        ""Dothraki"":  ""kem""
    },
    {
        ""English"":  ""marrige"",
        ""Dothraki"":  ""athkemar""
    },
    {
        ""English"":  ""marsh"",
        ""Dothraki"":  ""khizra""
    },
    {
        ""English"":  ""maybe"",
        ""Dothraki"":  ""ishish""
    },
    {
        ""English"":  ""me"",
        ""Dothraki"":  ""anna""
    },
    {
        ""English"":  ""meat"",
        ""Dothraki"":  ""gavat""
    },
    {
        ""English"":  ""meat of a nut"",
        ""Dothraki"":  ""zhor""
    },
    {
        ""English"":  ""medicine"",
        ""Dothraki"":  ""koala""
    },
    {
        ""English"":  ""mercenary"",
        ""Dothraki"":  ""chafak""
    },
    {
        ""English"":  ""merchant"",
        ""Dothraki"":  ""jerak""
    },
    {
        ""English"":  ""mercy men"",
        ""Dothraki"":  ""jaqqa rhan""
    },
    {
        ""English"":  ""mesage"",
        ""Dothraki"":  ""assokh""
    },
    {
        ""English"":  ""metal"",
        ""Dothraki"":  ""taoka""
    },
    {
        ""English"":  ""metal"",
        ""Dothraki"":  ""tawak""
    },
    {
        ""English"":  ""mettle"",
        ""Dothraki"":  ""oakah""
    },
    {
        ""English"":  ""midnight"",
        ""Dothraki"":  ""addo ajjalani""
    },
    {
        ""English"":  ""might"",
        ""Dothraki"":  ""ish""
    },
    {
        ""English"":  ""mile"",
        ""Dothraki"":  ""karlina""
    },
    {
        ""English"":  ""million"",
        ""Dothraki"":  ""yor""
    },
    {
        ""English"":  ""missing"",
        ""Dothraki"":  ""som""
    },
    {
        ""English"":  ""mole"",
        ""Dothraki"":  ""geve""
    },
    {
        ""English"":  ""moon"",
        ""Dothraki"":  ""jalan""
    },
    {
        ""English"":  ""more"",
        ""Dothraki"":  ""alikh""
    },
    {
        ""English"":  ""morning"",
        ""Dothraki"":  ""aena""
    },
    {
        ""English"":  ""mother"",
        ""Dothraki"":  ""mai""
    },
    {
        ""English"":  ""mother who is breastfeeding her child"",
        ""Dothraki"":  ""drane""
    },
    {
        ""English"":  ""mother’s milk"",
        ""Dothraki"":  ""dranekh""
    },
    {
        ""English"":  ""mountain"",
        ""Dothraki"":  ""krazaaj""
    },
    {
        ""English"":  ""mouse"",
        ""Dothraki"":  ""gimi""
    },
    {
        ""English"":  ""mouth of a human"",
        ""Dothraki"":  ""gomma""
    },
    {
        ""English"":  ""mouth of an animal"",
        ""Dothraki"":  ""hoska""
    },
    {
        ""English"":  ""moveable"",
        ""Dothraki"":  ""ovray""
    },
    {
        ""English"":  ""much"",
        ""Dothraki"":  ""san""
    },
    {
        ""English"":  ""mule"",
        ""Dothraki"":  ""enossho""
    },
    {
        ""English"":  ""muscle"",
        ""Dothraki"":  ""meso""
    },
    {
        ""English"":  ""must"",
        ""Dothraki"":  ""eth""
    },
    {
        ""English"":  ""mustang"",
        ""Dothraki"":  ""hrazef chafi""
    },
    {
        ""English"":  ""mysterions"",
        ""Dothraki"":  ""qemmemmo""
    },
    {
        ""English"":  ""nail"",
        ""Dothraki"":  ""tirikh""
    },
    {
        ""English"":  ""name"",
        ""Dothraki"":  ""hake""
    },
    {
        ""English"":  ""narrow"",
        ""Dothraki"":  ""thif""
    },
    {
        ""English"":  ""near"",
        ""Dothraki"":  ""qisi""
    },
    {
        ""English"":  ""nearby"",
        ""Dothraki"":  ""qisi""
    },
    {
        ""English"":  ""nearly"",
        ""Dothraki"":  ""chir""
    },
    {
        ""English"":  ""neck"",
        ""Dothraki"":  ""lenta""
    },
    {
        ""English"":  ""nectarine"",
        ""Dothraki"":  ""yachi norethmen""
    },
    {
        ""English"":  ""nephew"",
        ""Dothraki"":  ""siera""
    },
    {
        ""English"":  ""net"",
        ""Dothraki"":  ""kade""
    },
    {
        ""English"":  ""never"",
        ""Dothraki"":  ""avvos""
    },
    {
        ""English"":  ""new"",
        ""Dothraki"":  ""sash""
    },
    {
        ""English"":  ""next"",
        ""Dothraki"":  ""sille""
    },
    {
        ""English"":  ""nick"",
        ""Dothraki"":  ""koge""
    },
    {
        ""English"":  ""niece"",
        ""Dothraki"":  ""janise""
    },
    {
        ""English"":  ""nightmare"",
        ""Dothraki"":  ""athdrivarido""
    },
    {
        ""English"":  ""nine"",
        ""Dothraki"":  ""qazat""
    },
    {
        ""English"":  ""nine hundred"",
        ""Dothraki"":  ""qazatken""
    },
    {
        ""English"":  ""nineteen"",
        ""Dothraki"":  ""qazathi""
    },
    {
        ""English"":  ""ninety"",
        ""Dothraki"":  ""chiqazat""
    },
    {
        ""English"":  ""ninth"",
        ""Dothraki"":  ""qazatak""
    },
    {
        ""English"":  ""nipple"",
        ""Dothraki"":  ""theya""
    },
    {
        ""English"":  ""no"",
        ""Dothraki"":  ""vos""
    },
    {
        ""English"":  ""nonsense"",
        ""Dothraki"":  ""athastokhdeveshizar""
    },
    {
        ""English"":  ""north"",
        ""Dothraki"":  ""valshe""
    },
    {
        ""English"":  ""northeasterner"",
        ""Dothraki"":  ""valshtithak""
    },
    {
        ""English"":  ""northern"",
        ""Dothraki"":  ""valsh""
    },
    {
        ""English"":  ""northerner"",
        ""Dothraki"":  ""valshek""
    },
    {
        ""English"":  ""nose"",
        ""Dothraki"":  ""riv""
    },
    {
        ""English"":  ""not a lot"",
        ""Dothraki"":  ""vosan""
    },
    {
        ""English"":  ""not much"",
        ""Dothraki"":  ""vosan""
    },
    {
        ""English"":  ""not"",
        ""Dothraki"":  ""vos""
    },
    {
        ""English"":  ""nothing"",
        ""Dothraki"":  ""vosi""
    },
    {
        ""English"":  ""noun"",
        ""Dothraki"":  ""vekhikh""
    },
    {
        ""English"":  ""now"",
        ""Dothraki"":  ""ajjin""
    },
    {
        ""English"":  ""numerous"",
        ""Dothraki"":  ""samven""
    },
    {
        ""English"":  ""nut"",
        ""Dothraki"":  ""tif""
    },
    {
        ""English"":  ""oath"",
        ""Dothraki"":  ""asqoyi""
    },
    {
        ""English"":  ""obedient response"",
        ""Dothraki"":  ""ai""
    },
    {
        ""English"":  ""object"",
        ""Dothraki"":  ""vekhikh""
    },
    {
        ""English"":  ""occurrence"",
        ""Dothraki"":  ""melikh""
    },
    {
        ""English"":  ""of course not"",
        ""Dothraki"":  ""vosecchi""
    },
    {
        ""English"":  ""of mine"",
        ""Dothraki"":  ""anni""
    },
    {
        ""English"":  ""of poor quality"",
        ""Dothraki"":  ""edavrasa""
    },
    {
        ""English"":  ""of"",
        ""Dothraki"":  ""ki""
    },
    {
        ""English"":  ""off"",
        ""Dothraki"":  ""hezhah""
    },
    {
        ""English"":  ""old"",
        ""Dothraki"":  ""ershe""
    },
    {
        ""English"":  ""old"",
        ""Dothraki"":  ""foz""
    },
    {
        ""English"":  ""olive"",
        ""Dothraki"":  ""ewe""
    },
    {
        ""English"":  ""olive oil"",
        ""Dothraki"":  ""ewekh""
    },
    {
        ""English"":  ""olive pit"",
        ""Dothraki"":  ""ewweya""
    },
    {
        ""English"":  ""omen"",
        ""Dothraki"":  ""assikhqoyi""
    },
    {
        ""English"":  ""on account of"",
        ""Dothraki"":  ""haji""
    },
    {
        ""English"":  ""on"",
        ""Dothraki"":  ""she""
    },
    {
        ""English"":  ""one"",
        ""Dothraki"":  ""at""
    },
    {
        ""English"":  ""one who is respectful"",
        ""Dothraki"":  ""chomak""
    },
    {
        ""English"":  ""one who sounds like horse’s hooves"",
        ""Dothraki"":  ""fredrik""
    },
    {
        ""English"":  ""one’s own horse"",
        ""Dothraki"":  ""sajo""
    },
    {
        ""English"":  ""one"",
        ""Dothraki"":  ""ato""
    },
    {
        ""English"":  ""onion"",
        ""Dothraki"":  ""glas""
    },
    {
        ""English"":  ""only"",
        ""Dothraki"":  ""disse""
    },
    {
        ""English"":  ""onto"",
        ""Dothraki"":  ""she""
    },
    {
        ""English"":  ""opal"",
        ""Dothraki"":  ""kendra""
    },
    {
        ""English"":  ""opening"",
        ""Dothraki"":  ""ovrakh""
    },
    {
        ""English"":  ""opportunity"",
        ""Dothraki"":  ""ovrakh""
    },
    {
        ""English"":  ""or"",
        ""Dothraki"":  ""che""
    },
    {
        ""English"":  ""orange"",
        ""Dothraki"":  ""sathomakh""
    },
    {
        ""English"":  ""orderly"",
        ""Dothraki"":  ""kelen""
    },
    {
        ""English"":  ""organ"",
        ""Dothraki"":  ""rea""
    },
    {
        ""English"":  ""orgasm"",
        ""Dothraki"":  ""niqikkheya""
    },
    {
        ""English"":  ""original"",
        ""Dothraki"":  ""kim""
    },
    {
        ""English"":  ""orphan"",
        ""Dothraki"":  ""leishak""
    },
    {
        ""English"":  ""other"",
        ""Dothraki"":  ""eshna""
    },
    {
        ""English"":  ""our"",
        ""Dothraki"":  ""kishi""
    },
    {
        ""English"":  ""out of"",
        ""Dothraki"":  ""mra""
    },
    {
        ""English"":  ""over"",
        ""Dothraki"":  ""oleth""
    },
    {
        ""English"":  ""overview"",
        ""Dothraki"":  ""tihikhziri""
    },
    {
        ""English"":  ""owl"",
        ""Dothraki"":  ""idiro""
    },
    {
        ""English"":  ""own"",
        ""Dothraki"":  ""zhorre""
    },
    {
        ""English"":  ""pack"",
        ""Dothraki"":  ""moska""
    },
    {
        ""English"":  ""pain"",
        ""Dothraki"":  ""athnithar""
    },
    {
        ""English"":  ""painful"",
        ""Dothraki"":  ""nith""
    },
    {
        ""English"":  ""painless"",
        ""Dothraki"":  ""nithmen""
    },
    {
        ""English"":  ""painlessness"",
        ""Dothraki"":  ""athnithmenar""
    },
    {
        ""English"":  ""pale skinned"",
        ""Dothraki"":  ""messhihven""
    },
    {
        ""English"":  ""palimino horse"",
        ""Dothraki"":  ""qahlan""
    },
    {
        ""English"":  ""part"",
        ""Dothraki"":  ""saccheya""
    },
    {
        ""English"":  ""passive particle"",
        ""Dothraki"":  ""nem""
    },
    {
        ""English"":  ""path"",
        ""Dothraki"":  ""os""
    },
    {
        ""English"":  ""patterned"",
        ""Dothraki"":  ""kelen""
    },
    {
        ""English"":  ""pear"",
        ""Dothraki"":  ""sovi""
    },
    {
        ""English"":  ""pear brandy"",
        ""Dothraki"":  ""sovikh""
    },
    {
        ""English"":  ""pelt"",
        ""Dothraki"":  ""hemikh""
    },
    {
        ""English"":  ""perlino horse"",
        ""Dothraki"":  ""messhih""
    },
    {
        ""English"":  ""person"",
        ""Dothraki"":  ""na""
    },
    {
        ""English"":  ""pestle"",
        ""Dothraki"":  ""kafe""
    },
    {
        ""English"":  ""piece"",
        ""Dothraki"":  ""saccheya""
    },
    {
        ""English"":  ""pig"",
        ""Dothraki"":  ""qifo""
    },
    {
        ""English"":  ""pika"",
        ""Dothraki"":  ""choo""
    },
    {
        ""English"":  ""pile"",
        ""Dothraki"":  ""san""
    },
    {
        ""English"":  ""pink"",
        ""Dothraki"":  ""theyaven""
    },
    {
        ""English"":  ""pit of a fruit"",
        ""Dothraki"":  ""zhor""
    },
    {
        ""English"":  ""place"",
        ""Dothraki"":  ""gache""
    },
    {
        ""English"":  ""plain"",
        ""Dothraki"":  ""ramasar""
    },
    {
        ""English"":  ""plateau"",
        ""Dothraki"":  ""rayan""
    },
    {
        ""English"":  ""plum"",
        ""Dothraki"":  ""soqwi""
    },
    {
        ""English"":  ""plum tree"",
        ""Dothraki"":  ""soqwof""
    },
    {
        ""English"":  ""point on a route"",
        ""Dothraki"":  ""eleisosakh""
    },
    {
        ""English"":  ""poison"",
        ""Dothraki"":  ""ize""
    },
    {
        ""English"":  ""poison water"",
        ""Dothraki"":  ""evethiz""
    },
    {
        ""English"":  ""pomegranate"",
        ""Dothraki"":  ""daki""
    },
    {
        ""English"":  ""pony"",
        ""Dothraki"":  ""jedda""
    },
    {
        ""English"":  ""pork"",
        ""Dothraki"":  ""qifo""
    },
    {
        ""English"":  ""portable"",
        ""Dothraki"":  ""ovray""
    },
    {
        ""English"":  ""portion of meat"",
        ""Dothraki"":  ""vinte""
    },
    {
        ""English"":  ""powerful"",
        ""Dothraki"":  ""hrakkarikh""
    },
    {
        ""English"":  ""prayer"",
        ""Dothraki"":  ""asto""
    },
    {
        ""English"":  ""prepared food"",
        ""Dothraki"":  ""jolinikh""
    },
    {
        ""English"":  ""prepared"",
        ""Dothraki"":  ""hethke""
    },
    {
        ""English"":  ""pride"",
        ""Dothraki"":  ""athjahakar""
    },
    {
        ""English"":  ""prince"",
        ""Dothraki"":  ""khalakka""
    },
    {
        ""English"":  ""princess"",
        ""Dothraki"":  ""khalakki""
    },
    {
        ""English"":  ""prize"",
        ""Dothraki"":  ""qorasokh""
    },
    {
        ""English"":  ""prophecy"",
        ""Dothraki"":  ""assikhqoyisir""
    },
    {
        ""English"":  ""prowess"",
        ""Dothraki"":  ""athjahakar""
    },
    {
        ""English"":  ""puddle"",
        ""Dothraki"":  ""loy""
    },
    {
        ""English"":  ""pungent"",
        ""Dothraki"":  ""dave""
    },
    {
        ""English"":  ""purple"",
        ""Dothraki"":  ""reaven""
    },
    {
        ""English"":  ""queen"",
        ""Dothraki"":  ""khaleesi""
    },
    {
        ""English"":  ""question"",
        ""Dothraki"":  ""qaf""
    },
    {
        ""English"":  ""quiet"",
        ""Dothraki"":  ""haf""
    },
    {
        ""English"":  ""rabbit"",
        ""Dothraki"":  ""mawizzi""
    },
    {
        ""English"":  ""rain"",
        ""Dothraki"":  ""eyel""
    },
    {
        ""English"":  ""raisin"",
        ""Dothraki"":  ""rigwa""
    },
    {
        ""English"":  ""ramp"",
        ""Dothraki"":  ""yathokh""
    },
    {
        ""English"":  ""raptor"",
        ""Dothraki"":  ""zirqoyi""
    },
    {
        ""English"":  ""rat"",
        ""Dothraki"":  ""ni leqse""
    },
    {
        ""English"":  ""raven"",
        ""Dothraki"":  ""nhizo""
    },
    {
        ""English"":  ""re"",
        ""Dothraki"":  ""akka""
    },
    {
        ""English"":  ""real"",
        ""Dothraki"":  ""tawak""
    },
    {
        ""English"":  ""really sexy"",
        ""Dothraki"":  ""mezahhe""
    },
    {
        ""English"":  ""really"",
        ""Dothraki"":  ""sekke""
    },
    {
        ""English"":  ""reason why"",
        ""Dothraki"":  ""velzerikh""
    },
    {
        ""English"":  ""red"",
        ""Dothraki"":  ""virzeth""
    },
    {
        ""English"":  ""red wine"",
        ""Dothraki"":  ""virzetha""
    },
    {
        ""English"":  ""reflexive particle"",
        ""Dothraki"":  ""nemo""
    },
    {
        ""English"":  ""refuse"",
        ""Dothraki"":  ""graddakh""
    },
    {
        ""English"":  ""reins"",
        ""Dothraki"":  ""javrath""
    },
    {
        ""English"":  ""remaining"",
        ""Dothraki"":  ""zinay""
    },
    {
        ""English"":  ""repetitive"",
        ""Dothraki"":  ""qoth""
    },
    {
        ""English"":  ""required"",
        ""Dothraki"":  ""zigere""
    },
    {
        ""English"":  ""requisite"",
        ""Dothraki"":  ""zigere""
    },
    {
        ""English"":  ""respect"",
        ""Dothraki"":  ""athchomar""
    },
    {
        ""English"":  ""respectable"",
        ""Dothraki"":  ""vichomer""
    },
    {
        ""English"":  ""respectful one"",
        ""Dothraki"":  ""vichomerak""
    },
    {
        ""English"":  ""respectful"",
        ""Dothraki"":  ""vichomer""
    },
    {
        ""English"":  ""response"",
        ""Dothraki"":  ""elzikh""
    },
    {
        ""English"":  ""rest"",
        ""Dothraki"":  ""athmithrar""
    },
    {
        ""English"":  ""return"",
        ""Dothraki"":  ""athessazar""
    },
    {
        ""English"":  ""reverence"",
        ""Dothraki"":  ""athchomar""
    },
    {
        ""English"":  ""rice"",
        ""Dothraki"":  ""gamiz""
    },
    {
        ""English"":  ""ride"",
        ""Dothraki"":  ""dothrakh""
    },
    {
        ""English"":  ""rider"",
        ""Dothraki"":  ""dothrak""
    },
    {
        ""English"":  ""right"",
        ""Dothraki"":  ""haje(direction)""
    },
    {
        ""English"":  ""right side"",
        ""Dothraki"":  ""hajekh""
    },
    {
        ""English"":  ""rightfully"",
        ""Dothraki"":  ""kathjilari""
    },
    {
        ""English"":  ""rightful"",
        ""Dothraki"":  ""jil""
    },
    {
        ""English"":  ""rightness"",
        ""Dothraki"":  ""athjilar""
    },
    {
        ""English"":  ""rigid"",
        ""Dothraki"":  ""niqe""
    },
    {
        ""English"":  ""rigidity"",
        ""Dothraki"":  ""athniqar""
    },
    {
        ""English"":  ""rim"",
        ""Dothraki"":  ""heth""
    },
    {
        ""English"":  ""ring"",
        ""Dothraki"":  ""firikh""
    },
    {
        ""English"":  ""rip"",
        ""Dothraki"":  ""gende""
    },
    {
        ""English"":  ""ripped"",
        ""Dothraki"":  ""gende""
    },
    {
        ""English"":  ""river"",
        ""Dothraki"":  ""ashefa""
    },
    {
        ""English"":  ""road"",
        ""Dothraki"":  ""os""
    },
    {
        ""English"":  ""roof"",
        ""Dothraki"":  ""essheya""
    },
    {
        ""English"":  ""root"",
        ""Dothraki"":  ""garfoth""
    },
    {
        ""English"":  ""rope"",
        ""Dothraki"":  ""fiez""
    },
    {
        ""English"":  ""rose"",
        ""Dothraki"":  ""hanna""
    },
    {
        ""English"":  ""rosemary"",
        ""Dothraki"":  ""davveya""
    },
    {
        ""English"":  ""rosemary bush"",
        ""Dothraki"":  ""dave""
    },
    {
        ""English"":  ""rotten"",
        ""Dothraki"":  ""rikh""
    },
    {
        ""English"":  ""round"",
        ""Dothraki"":  ""fir""
    },
    {
        ""English"":  ""round road"",
        ""Dothraki"":  ""osfir""
    },
    {
        ""English"":  ""ruby"",
        ""Dothraki"":  ""ozzir""
    },
    {
        ""English"":  ""running"",
        ""Dothraki"":  ""athlanar""
    },
    {
        ""English"":  ""rythmic noise"",
        ""Dothraki"":  ""oqo""
    },
    {
        ""English"":  ""sack"",
        ""Dothraki"":  ""moska""
    },
    {
        ""English"":  ""saddle"",
        ""Dothraki"":  ""darif""
    },
    {
        ""English"":  ""safe"",
        ""Dothraki"":  ""sandi""
    },
    {
        ""English"":  ""said at parting"",
        ""Dothraki"":  ""fonas cheklit ""
    },
    {
        ""English"":  ""salad"",
        ""Dothraki"":  ""ilmeser""
    },
    {
        ""English"":  ""salmon"",
        ""Dothraki"":  ""joma""
    },
    {
        ""English"":  ""salt"",
        ""Dothraki"":  ""zhif""
    },
    {
        ""English"":  ""salty"",
        ""Dothraki"":  ""zhifven""
    },
    {
        ""English"":  ""sand"",
        ""Dothraki"":  ""qeshah""
    },
    {
        ""English"":  ""satchel"",
        ""Dothraki"":  ""zande""
    },
    {
        ""English"":  ""sausage"",
        ""Dothraki"":  ""nindi""
    },
    {
        ""English"":  ""saying"",
        ""Dothraki"":  ""asto""
    },
    {
        ""English"":  ""scorpion"",
        ""Dothraki"":  ""shiro""
    },
    {
        ""English"":  ""scratch"",
        ""Dothraki"":  ""zisosh""
    },
    {
        ""English"":  ""screamer"",
        ""Dothraki"":  ""awazak""
    },
    {
        ""English"":  ""sea"",
        ""Dothraki"":  ""havazh""
    },
    {
        ""English"":  ""sealed"",
        ""Dothraki"":  ""jon""
    },
    {
        ""English"":  ""second"",
        ""Dothraki"":  ""akataki""
    },
    {
        ""English"":  ""seed"",
        ""Dothraki"":  ""elain""
    },
    {
        ""English"":  ""semblance"",
        ""Dothraki"":  ""venikh""
    },
    {
        ""English"":  ""setting sun"",
        ""Dothraki"":  ""shekh drivo""
    },
    {
        ""English"":  ""seven"",
        ""Dothraki"":  ""fekh""
    },
    {
        ""English"":  ""seven hundred"",
        ""Dothraki"":  ""fekhken""
    },
    {
        ""English"":  ""seventeen"",
        ""Dothraki"":  ""fekhthi""
    },
    {
        ""English"":  ""seventh"",
        ""Dothraki"":  ""fekhak""
    },
    {
        ""English"":  ""seventy"",
        ""Dothraki"":  ""chifekh""
    },
    {
        ""English"":  ""sex"",
        ""Dothraki"":  ""athhilezar""
    },
    {
        ""English"":  ""sexy"",
        ""Dothraki"":  ""mezahe""
    },
    {
        ""English"":  ""shackle"",
        ""Dothraki"":  ""efe""
    },
    {
        ""English"":  ""shade"",
        ""Dothraki"":  ""zanisshi""
    },
    {
        ""English"":  ""shallow"",
        ""Dothraki"":  ""dei""
    },
    {
        ""English"":  ""shaming"",
        ""Dothraki"":  ""arrane""
    },
    {
        ""English"":  ""sharp"",
        ""Dothraki"":  ""has""
    },
    {
        ""English"":  ""she"",
        ""Dothraki"":  ""me""
    },
    {
        ""English"":  ""sheep"",
        ""Dothraki"":  ""oqet""
    },
    {
        ""English"":  ""ship"",
        ""Dothraki"":  ""rhaggat eveth""
    },
    {
        ""English"":  ""shit"",
        ""Dothraki"":  ""graddakh""
    },
    {
        ""English"":  ""shoe"",
        ""Dothraki"":  ""orzi""
    },
    {
        ""English"":  ""short"",
        ""Dothraki"":  ""fitte""
    },
    {
        ""English"":  ""shoulder"",
        ""Dothraki"":  ""elme""
    },
    {
        ""English"":  ""shriveled"",
        ""Dothraki"":  ""rof""
    },
    {
        ""English"":  ""shut"",
        ""Dothraki"":  ""jon""
    },
    {
        ""English"":  ""sickness"",
        ""Dothraki"":  ""athzhikhar""
    },
    {
        ""English"":  ""sign"",
        ""Dothraki"":  ""assikhqoyi""
    },
    {
        ""English"":  ""silent"",
        ""Dothraki"":  ""chak""
    },
    {
        ""English"":  ""silk"",
        ""Dothraki"":  ""tasokh""
    },
    {
        ""English"":  ""silkworm"",
        ""Dothraki"":  ""taso""
    },
    {
        ""English"":  ""silver"",
        ""Dothraki"":  ""vizhadi""
    },
    {
        ""English"":  ""simple"",
        ""Dothraki"":  ""dis""
    },
    {
        ""English"":  ""simplicity"",
        ""Dothraki"":  ""athdisizar""
    },
    {
        ""English"":  ""simply"",
        ""Dothraki"":  ""disse""
    },
    {
        ""English"":  ""sister"",
        ""Dothraki"":  ""inavva""
    },
    {
        ""English"":  ""sitting-spot"",
        ""Dothraki"":  ""nevakh""
    },
    {
        ""English"":  ""six"",
        ""Dothraki"":  ""zhinda""
    },
    {
        ""English"":  ""six hundred"",
        ""Dothraki"":  ""zhindaken""
    },
    {
        ""English"":  ""sixteen"",
        ""Dothraki"":  ""zhinthi""
    },
    {
        ""English"":  ""sixth"",
        ""Dothraki"":  ""zhindak""
    },
    {
        ""English"":  ""sixty"",
        ""Dothraki"":  ""chizhinda""
    },
    {
        ""English"":  ""size"",
        ""Dothraki"":  ""athzhokwazar""
    },
    {
        ""English"":  ""skin"",
        ""Dothraki"":  ""ilek""
    },
    {
        ""English"":  ""skin of an animal"",
        ""Dothraki"":  ""kher""
    },
    {
        ""English"":  ""skinny"",
        ""Dothraki"":  ""reddi""
    },
    {
        ""English"":  ""skull"",
        ""Dothraki"":  ""diaf""
    },
    {
        ""English"":  ""sky"",
        ""Dothraki"":  ""asavva""
    },
    {
        ""English"":  ""slang for an annoying woman"",
        ""Dothraki"":  ""vikeesi""
    },
    {
        ""English"":  ""slang for one’s own khalasar"",
        ""Dothraki"":  ""dozgosor""
    },
    {
        ""English"":  ""slave"",
        ""Dothraki"":  ""zafra""
    },
    {
        ""English"":  ""slaver"",
        ""Dothraki"":  ""azzafrok""
    },
    {
        ""English"":  ""sleek"",
        ""Dothraki"":  ""redda""
    },
    {
        ""English"":  ""slow"",
        ""Dothraki"":  ""vroz""
    },
    {
        ""English"":  ""small"",
        ""Dothraki"":  ""naqis""
    },
    {
        ""English"":  ""small group of protectors"",
        ""Dothraki"":  ""khasar""
    },
    {
        ""English"":  ""smelly"",
        ""Dothraki"":  ""achra""
    },
    {
        ""English"":  ""smile"",
        ""Dothraki"":  ""eme""
    },
    {
        ""English"":  ""smiley"",
        ""Dothraki"":  ""emesh""
    },
    {
        ""English"":  ""smoke"",
        ""Dothraki"":  ""fih""
    },
    {
        ""English"":  ""smooth"",
        ""Dothraki"":  ""es""
    },
    {
        ""English"":  ""smudged"",
        ""Dothraki"":  ""shoven""
    },
    {
        ""English"":  ""snake:"",
        ""Dothraki"":  ""gezri""
    },
    {
        ""English"":  ""sniff"",
        ""Dothraki"":  ""rivve""
    },
    {
        ""English"":  ""snore"",
        ""Dothraki"":  ""shigi""
    },
    {
        ""English"":  ""snow"",
        ""Dothraki"":  ""ahesh""
    },
    {
        ""English"":  ""so"",
        ""Dothraki"":  ""majin""
    },
    {
        ""English"":  ""soft"",
        ""Dothraki"":  ""thash""
    },
    {
        ""English"":  ""soft"",
        ""Dothraki"":  ""haf""
    },
    {
        ""English"":  ""some"",
        ""Dothraki"":  ""zolle""
    },
    {
        ""English"":  ""someone responsible for someone’s death"",
        ""Dothraki"":  ""jaqqa""
    },
    {
        ""English"":  ""something"",
        ""Dothraki"":  ""ato""
    },
    {
        ""English"":  ""son"",
        ""Dothraki"":  ""rizh""
    },
    {
        ""English"":  ""son of a khal"",
        ""Dothraki"":  ""khalakka""
    },
    {
        ""English"":  ""song"",
        ""Dothraki"":  ""hoyali""
    },
    {
        ""English"":  ""sorceress"",
        ""Dothraki"":  ""maegi""
    },
    {
        ""English"":  ""sore"",
        ""Dothraki"":  ""mhar""
    },
    {
        ""English"":  ""sore-foot"",
        ""Dothraki"":  ""rhae mhar""
    },
    {
        ""English"":  ""soreness"",
        ""Dothraki"":  ""athmharar""
    },
    {
        ""English"":  ""sound"",
        ""Dothraki"":  ""mem""
    },
    {
        ""English"":  ""sound of fire going out"",
        ""Dothraki"":  ""shin""
    },
    {
        ""English"":  ""sound of horse’s hooves on dirt"",
        ""Dothraki"":  ""fredri""
    },
    {
        ""English"":  ""sound used to calm a horse or child"",
        ""Dothraki"":  ""affa""
    },
    {
        ""English"":  ""soup"",
        ""Dothraki"":  ""mesina""
    },
    {
        ""English"":  ""sour"",
        ""Dothraki"":  ""jelaven""
    },
    {
        ""English"":  ""south"",
        ""Dothraki"":  ""heske""
    },
    {
        ""English"":  ""southern"",
        ""Dothraki"":  ""hesk""
    },
    {
        ""English"":  ""sparkle"",
        ""Dothraki"":  ""dili""
    },
    {
        ""English"":  ""spawn"",
        ""Dothraki"":  ""haesh""
    },
    {
        ""English"":  ""spear"",
        ""Dothraki"":  ""zhani""
    },
    {
        ""English"":  ""species of forest spider"",
        ""Dothraki"":  ""ifeqevron""
    },
    {
        ""English"":  ""speed"",
        ""Dothraki"":  ""athdikar""
    },
    {
        ""English"":  ""sperm"",
        ""Dothraki"":  ""elain""
    },
    {
        ""English"":  ""spider"",
        ""Dothraki"":  ""qosar""
    },
    {
        ""English"":  ""spoils"",
        ""Dothraki"":  ""qorasokh""
    },
    {
        ""English"":  ""spot"",
        ""Dothraki"":  ""sho""
    },
    {
        ""English"":  ""spotted"",
        ""Dothraki"":  ""eyeli""
    },
    {
        ""English"":  ""spouse"",
        ""Dothraki"":  ""kemak""
    },
    {
        ""English"":  ""spring"",
        ""Dothraki"":  ""eyelke""
    },
    {
        ""English"":  ""stable"",
        ""Dothraki"":  ""zan""
    },
    {
        ""English"":  ""stallion"",
        ""Dothraki"":  ""vezh""
    },
    {
        ""English"":  ""stampede"",
        ""Dothraki"":  ""vash""
    },
    {
        ""English"":  ""stand up"",
        ""Dothraki"":  ""akko""
    },
    {
        ""English"":  ""star"",
        ""Dothraki"":  ""shierak""
    },
    {
        ""English"":  ""stay"",
        ""Dothraki"":  ""reri""
    },
    {
        ""English"":  ""steadfast"",
        ""Dothraki"":  ""zan""
    },
    {
        ""English"":  ""steed"",
        ""Dothraki"":  ""sajo""
    },
    {
        ""English"":  ""stem"",
        ""Dothraki"":  ""lenta""
    },
    {
        ""English"":  ""stew"",
        ""Dothraki"":  ""lashfak""
    },
    {
        ""English"":  ""stick"",
        ""Dothraki"":  ""kerikh""
    },
    {
        ""English"":  ""still"",
        ""Dothraki"":  ""zin""
    },
    {
        ""English"":  ""stink"",
        ""Dothraki"":  ""achrakh""
    },
    {
        ""English"":  ""stirrup"",
        ""Dothraki"":  ""rhiko""
    },
    {
        ""English"":  ""stomach"",
        ""Dothraki"":  ""torga""
    },
    {
        ""English"":  ""stone"",
        ""Dothraki"":  ""negwin""
    },
    {
        ""English"":  ""stone house"",
        ""Dothraki"":  ""okrenegwin""
    },
    {
        ""English"":  ""stop"",
        ""Dothraki"":  ""nakho""
    },
    {
        ""English"":  ""stor"",
        ""Dothraki"":  ""kqana""
    },
    {
        ""English"":  ""storm"",
        ""Dothraki"":  ""vaz""
    },
    {
        ""English"":  ""stormborn"",
        ""Dothraki"":  ""vazyol""
    },
    {
        ""English"":  ""straight"",
        ""Dothraki"":  ""nris""
    },
    {
        ""English"":  ""strange"",
        ""Dothraki"":  ""qemmemmo""
    },
    {
        ""English"":  ""strength"",
        ""Dothraki"":  ""athhajar""
    },
    {
        ""English"":  ""stride"",
        ""Dothraki"":  ""rhaesof""
    },
    {
        ""English"":  ""strong"",
        ""Dothraki"":  ""haj""
    },
    {
        ""English"":  ""stud"",
        ""Dothraki"":  ""rhaek""
    },
    {
        ""English"":  ""subject"",
        ""Dothraki"":  ""silak""
    },
    {
        ""English"":  ""subject"",
        ""Dothraki"":  ""aranikh""
    },
    {
        ""English"":  ""sufficiently"",
        ""Dothraki"":  ""lekhaan""
    },
    {
        ""English"":  ""suitably warm"",
        ""Dothraki"":  ""ita""
    },
    {
        ""English"":  ""summer"",
        ""Dothraki"":  ""vorsaska""
    },
    {
        ""English"":  ""summit"",
        ""Dothraki"":  ""rayan""
    },
    {
        ""English"":  ""sun"",
        ""Dothraki"":  ""shekh""
    },
    {
        ""English"":  ""sunset"",
        ""Dothraki"":  ""athdrivar shekhi""
    },
    {
        ""English"":  ""supine"",
        ""Dothraki"":  ""chilay""
    },
    {
        ""English"":  ""surely"",
        ""Dothraki"":  ""sekosshi""
    },
    {
        ""English"":  ""sweet"",
        ""Dothraki"":  ""gizikhven""
    },
    {
        ""English"":  ""swelling"",
        ""Dothraki"":  ""rich""
    },
    {
        ""English"":  ""sword strike"",
        ""Dothraki"":  ""ildo""
    },
    {
        ""English"":  ""tail"",
        ""Dothraki"":  ""eve""
    },
    {
        ""English"":  ""tame"",
        ""Dothraki"":  ""shim""
    },
    {
        ""English"":  ""task"",
        ""Dothraki"":  ""thikh""
    },
    {
        ""English"":  ""taste"",
        ""Dothraki"":  ""lekhi""
    },
    {
        ""English"":  ""tattoo"",
        ""Dothraki"":  ""lir""
    },
    {
        ""English"":  ""tattoo artist"",
        ""Dothraki"":  ""lirak""
    },
    {
        ""English"":  ""tattoos"",
        ""Dothraki"":  ""lirisir""
    },
    {
        ""English"":  ""tear"",
        ""Dothraki"":  ""laqikh""
    },
    {
        ""English"":  ""tears"",
        ""Dothraki"":  ""laqikh""
    },
    {
        ""English"":  ""ten"",
        ""Dothraki"":  ""thi""
    },
    {
        ""English"":  ""tent"",
        ""Dothraki"":  ""okre""
    },
    {
        ""English"":  ""tenth"",
        ""Dothraki"":  ""thik""
    },
    {
        ""English"":  ""that"",
        ""Dothraki"":  ""reki""
    },
    {
        ""English"":  ""thus"",
        ""Dothraki"":  ""ki""
    },
    {
        ""English"":  ""that place"",
        ""Dothraki"":  ""loc""
    },
    {
        ""English"":  ""the instigator’s half of the act"",
        ""Dothraki"":  ""tikkheya""
    },
    {
        ""English"":  ""the last"",
        ""Dothraki"":  ""nakhok""
    },
    {
        ""English"":  ""the patient’s half of the act"",
        ""Dothraki"":  ""melikheya""
    },
    {
        ""English"":  ""the same way"",
        ""Dothraki"":  ""akkate""
    },
    {
        ""English"":  ""the whole time"",
        ""Dothraki"":  ""evoon""
    },
    {
        ""English"":  ""theme"",
        ""Dothraki"":  ""aranikh""
    },
    {
        ""English"":  ""then"",
        ""Dothraki"":  ""arrek""
    },
    {
        ""English"":  ""there"",
        ""Dothraki"":  ""hazze""
    },
    {
        ""English"":  ""they"",
        ""Dothraki"":  ""mori""
    },
    {
        ""English"":  ""thick"",
        ""Dothraki"":  ""nroj""
    },
    {
        ""English"":  ""thin"",
        ""Dothraki"":  ""redda""
    },
    {
        ""English"":  ""thing"",
        ""Dothraki"":  ""vekhikh""
    },
    {
        ""English"":  ""third"",
        ""Dothraki"":  ""senak""
    },
    {
        ""English"":  ""thirteen"",
        ""Dothraki"":  ""senthi""
    },
    {
        ""English"":  ""thirty"",
        ""Dothraki"":  ""chisen""
    },
    {
        ""English"":  ""this"",
        ""Dothraki"":  ""jin""
    },
    {
        ""English"":  ""thorn"",
        ""Dothraki"":  ""mihe""
    },
    {
        ""English"":  ""thought"",
        ""Dothraki"":  ""dirge""
    },
    {
        ""English"":  ""thousand"",
        ""Dothraki"":  ""dalen""
    },
    {
        ""English"":  ""three"",
        ""Dothraki"":  ""sen""
    },
    {
        ""English"":  ""three hundred"",
        ""Dothraki"":  ""senken""
    },
    {
        ""English"":  ""throat"",
        ""Dothraki"":  ""fotha""
    },
    {
        ""English"":  ""through"",
        ""Dothraki"":  ""vi""
    },
    {
        ""English"":  ""thunder"",
        ""Dothraki"":  ""temme""
    },
    {
        ""English"":  ""thus"",
        ""Dothraki"":  ""kijinosi""
    },
    {
        ""English"":  ""tiger"",
        ""Dothraki"":  ""rachel""
    },
    {
        ""English"":  ""tight"",
        ""Dothraki"":  ""hethke""
    },
    {
        ""English"":  ""time"",
        ""Dothraki"":  ""kashi""
    },
    {
        ""English"":  ""time period of approximately 2 minutes"",
        ""Dothraki"":  ""leshitof""
    },
    {
        ""English"":  ""tip"",
        ""Dothraki"":  ""riv""
    },
    {
        ""English"":  ""tired"",
        ""Dothraki"":  ""haqe""
    },
    {
        ""English"":  ""to ache"",
        ""Dothraki"":  ""ziroqoselat""
    },
    {
        ""English"":  ""to ally with someone"",
        ""Dothraki"":  ""kemisolat""
    },
    {
        ""English"":  ""to amuse"",
        ""Dothraki"":  ""emmat""
    },
    {
        ""English"":  ""to approach"",
        ""Dothraki"":  ""jadilat""
    },
    {
        ""English"":  ""to approve of"",
        ""Dothraki"":  ""emat""
    },
    {
        ""English"":  ""to arrive"",
        ""Dothraki"":  ""jadolat""
    },
    {
        ""English"":  ""to ask"",
        ""Dothraki"":  ""qafat""
    },
    {
        ""English"":  ""to attach"",
        ""Dothraki"":  ""fenat""
    },
    {
        ""English"":  ""to bathe"",
        ""Dothraki"":  ""lommat""
    },
    {
        ""English"":  ""to be able to"",
        ""Dothraki"":  ""devolat""
    },
    {
        ""English"":  ""to be beautiful"",
        ""Dothraki"":  ""lainat""
    },
    {
        ""English"":  ""to be bitter"",
        ""Dothraki"":  ""choakat""
    },
    {
        ""English"":  ""to be bloody"",
        ""Dothraki"":  ""saqoyalat""
    },
    {
        ""English"":  ""to be born"",
        ""Dothraki"":  ""yolat""
    },
    {
        ""English"":  ""to be certain"",
        ""Dothraki"":  ""goshat""
    },
    {
        ""English"":  ""to be correct"",
        ""Dothraki"":  ""jilat""
    },
    {
        ""English"":  ""to be dead"",
        ""Dothraki"":  ""drivat""
    },
    {
        ""English"":  ""to be different"",
        ""Dothraki"":  ""esinalat""
    },
    {
        ""English"":  ""to be empty"",
        ""Dothraki"":  ""menatto be empty""
    },
    {
        ""English"":  ""to be evil"",
        ""Dothraki"":  ""melat""
    },
    {
        ""English"":  ""to be exceptionally small"",
        ""Dothraki"":  ""zolat""
    },
    {
        ""English"":  ""to be familiar with"",
        ""Dothraki"":  ""shilat""
    },
    {
        ""English"":  ""to be finished"",
        ""Dothraki"":  ""malilat""
    },
    {
        ""English"":  ""to be for"",
        ""Dothraki"":  ""movekkhat""
    },
    {
        ""English"":  ""to be full"",
        ""Dothraki"":  ""nirat""
    },
    {
        ""English"":  ""to be full of"",
        ""Dothraki"":  ""nirat""
    },
    {
        ""English"":  ""to be good"",
        ""Dothraki"":  ""erinat""
    },
    {
        ""English"":  ""to be happy"",
        ""Dothraki"":  ""layafat""
    },
    {
        ""English"":  ""to be hard"",
        ""Dothraki"":  ""chongat""
    },
    {
        ""English"":  ""to be healthy"",
        ""Dothraki"":  ""sharat""
    },
    {
        ""English"":  ""to be heavy"",
        ""Dothraki"":  ""ohazhat""
    },
    {
        ""English"":  ""to be hurt"",
        ""Dothraki"":  ""zisat""
    },
    {
        ""English"":  ""to be incorrect"",
        ""Dothraki"":  ""ojilat""
    },
    {
        ""English"":  ""to be intended for"",
        ""Dothraki"":  ""movekkhat""
    },
    {
        ""English"":  ""to be kind"",
        ""Dothraki"":  ""erinat""
    },
    {
        ""English"":  ""to be large"",
        ""Dothraki"":  ""zhokwalat""
    },
    {
        ""English"":  ""to be like"",
        ""Dothraki"":  ""venat""
    },
    {
        ""English"":  ""to be loud"",
        ""Dothraki"":  ""lavakhat""
    },
    {
        ""English"":  ""to be loyal"",
        ""Dothraki"":  ""qothat""
    },
    {
        ""English"":  ""to be merciful"",
        ""Dothraki"":  ""rhanat""
    },
    {
        ""English"":  ""to be neglected"",
        ""Dothraki"":  ""arannat""
    },
    {
        ""English"":  ""to be new"",
        ""Dothraki"":  ""meshat""
    },
    {
        ""English"":  ""to be of help"",
        ""Dothraki"":  ""koalat""
    },
    {
        ""English"":  ""to be poisonous"",
        ""Dothraki"":  ""izat""
    },
    {
        ""English"":  ""to be pregnant"",
        ""Dothraki"":  ""mesilat""
    },
    {
        ""English"":  ""to be present"",
        ""Dothraki"":  ""vekhat""
    },
    {
        ""English"":  ""to be protected"",
        ""Dothraki"":  ""savidosalat""
    },
    {
        ""English"":  ""to be repetitive"",
        ""Dothraki"":  ""qothat""
    },
    {
        ""English"":  ""to be respectful"",
        ""Dothraki"":  ""vichomerat""
    },
    {
        ""English"":  ""to be respectul"",
        ""Dothraki"":  ""chomat""
    },
    {
        ""English"":  ""to be righ"",
        ""Dothraki"":  ""jilat""
    },
    {
        ""English"":  ""to be ripped"",
        ""Dothraki"":  ""gendat""
    },
    {
        ""English"":  ""to be sad"",
        ""Dothraki"":  ""khezhat""
    },
    {
        ""English"":  ""to be sick"",
        ""Dothraki"":  ""zhikhat""
    },
    {
        ""English"":  ""to be silent"",
        ""Dothraki"":  ""chakat""
    },
    {
        ""English"":  ""to be similar to"",
        ""Dothraki"":  ""venat""
    },
    {
        ""English"":  ""to be small"",
        ""Dothraki"":  ""naqisat""
    },
    {
        ""English"":  ""to be smelly"",
        ""Dothraki"":  ""achralat""
    },
    {
        ""English"":  ""to be spotted"",
        ""Dothraki"":  ""eyelilat""
    },
    {
        ""English"":  ""to be still"",
        ""Dothraki"":  ""oholat""
    },
    {
        ""English"":  ""to be sure"",
        ""Dothraki"":  ""goshat""
    },
    {
        ""English"":  ""to be swollen"",
        ""Dothraki"":  ""mesat""
    },
    {
        ""English"":  ""to be thick"",
        ""Dothraki"":  ""nrojat""
    },
    {
        ""English"":  ""to be tired"",
        ""Dothraki"":  ""haqat""
    },
    {
        ""English"":  ""to be torn"",
        ""Dothraki"":  ""gendat""
    },
    {
        ""English"":  ""to be tough"",
        ""Dothraki"":  ""nizhat""
    },
    {
        ""English"":  ""to be useful"",
        ""Dothraki"":  ""davralat""
    },
    {
        ""English"":  ""to be useful to"",
        ""Dothraki"":  ""davralat""
    },
    {
        ""English"":  ""to be venomous"",
        ""Dothraki"":  ""izat""
    },
    {
        ""English"":  ""to be victorious"",
        ""Dothraki"":  ""najahat""
    },
    {
        ""English"":  ""to be wet"",
        ""Dothraki"":  ""diwelat""
    },
    {
        ""English"":  ""to be wise"",
        ""Dothraki"":  ""villat""
    },
    {
        ""English"":  ""to be wrong"",
        ""Dothraki"":  ""ojilat""
    },
    {
        ""English"":  ""to be young"",
        ""Dothraki"":  ""imeshat""
    },
    {
        ""English"":  ""to beat"",
        ""Dothraki"":  ""oqolat""
    },
    {
        ""English"":  ""to become heavy"",
        ""Dothraki"":  ""ohazholat""
    },
    {
        ""English"":  ""to become ripped"",
        ""Dothraki"":  ""gendolat""
    },
    {
        ""English"":  ""to before"",
        ""Dothraki"":  ""hatif""
    },
    {
        ""English"":  ""to beg"",
        ""Dothraki"":  ""viqaferat""
    },
    {
        ""English"":  ""to behin"",
        ""Dothraki"":  ""irge""
    },
    {
        ""English"":  ""to believe"",
        ""Dothraki"":  ""shillolat""
    },
    {
        ""English"":  ""to bite"",
        ""Dothraki"":  ""ostat""
    },
    {
        ""English"":  ""to bleed"",
        ""Dothraki"":  ""qiyalat""
    },
    {
        ""English"":  ""to blink"",
        ""Dothraki"":  ""lorrat""
    },
    {
        ""English"":  ""to block"",
        ""Dothraki"":  ""jazat""
    },
    {
        ""English"":  ""to block"",
        ""Dothraki"":  ""jezat""
    },
    {
        ""English"":  ""to blow"",
        ""Dothraki"":  ""jekhtat""
    },
    {
        ""English"":  ""to bounce"",
        ""Dothraki"":  ""jekhtat""
    },
    {
        ""English"":  ""to brag"",
        ""Dothraki"":  ""esittesalat""
    },
    {
        ""English"":  ""to break"",
        ""Dothraki"":  ""samvolat""
    },
    {
        ""English"":  ""to break a horse"",
        ""Dothraki"":  ""vishaferat""
    },
    {
        ""English"":  ""to breathe"",
        ""Dothraki"":  ""leshitat""
    },
    {
        ""English"":  ""to bring"",
        ""Dothraki"":  ""fichat""
    },
    {
        ""English"":  ""to bug"",
        ""Dothraki"":  ""zireyeselat""
    },
    {
        ""English"":  ""to burden"",
        ""Dothraki"":  ""ziganelat""
    },
    {
        ""English"":  ""to burn"",
        ""Dothraki"":  ""virsalat""
    },
    {
        ""English"":  ""to burn out"",
        ""Dothraki"":  ""shinat""
    },
    {
        ""English"":  ""to burn something"",
        ""Dothraki"":  ""avvirsalat""
    },
    {
        ""English"":  ""to camp"",
        ""Dothraki"":  ""vimithrerat""
    },
    {
        ""English"":  ""to canter"",
        ""Dothraki"":  ""chetirat""
    },
    {
        ""English"":  ""to canter beside"",
        ""Dothraki"":  ""chetirat""
    },
    {
        ""English"":  ""to capture"",
        ""Dothraki"":  ""kadat""
    },
    {
        ""English"":  ""to carry"",
        ""Dothraki"":  ""kesselat""
    },
    {
        ""English"":  ""to contain"",
        ""Dothraki"":  ""loshat""
    },
    {
        ""English"":  ""to cause pain"",
        ""Dothraki"":  ""annithat""
    },
    {
        ""English"":  ""to cause to be merciful"",
        ""Dothraki"":  ""arranat""
    },
    {
        ""English"":  ""to cause to spill"",
        ""Dothraki"":  ""addrekat""
    },
    {
        ""English"":  ""to change"",
        ""Dothraki"":  ""esinasolat""
    },
    {
        ""English"":  ""to charge a horse"",
        ""Dothraki"":  ""gorat""
    },
    {
        ""English"":  ""to check or guide a horse with the reins"",
        ""Dothraki"":  ""javrathat""
    },
    {
        ""English"":  ""to chew"",
        ""Dothraki"":  ""lakkhat""
    },
    {
        ""English"":  ""to choke"",
        ""Dothraki"":  ""arraggat""
    },
    {
        ""English"":  ""to choose"",
        ""Dothraki"":  ""okkat""
    },
    {
        ""English"":  ""to clean"",
        ""Dothraki"":  ""affisat""
    },
    {
        ""English"":  ""to clench"",
        ""Dothraki"":  ""himat""
    },
    {
        ""English"":  ""to clog"",
        ""Dothraki"":  ""vaesilat""
    },
    {
        ""English"":  ""to collect"",
        ""Dothraki"":  ""yanqolat""
    },
    {
        ""English"":  ""to come"",
        ""Dothraki"":  ""jadat""
    },
    {
        ""English"":  ""to come to spill"",
        ""Dothraki"":  ""drekolat""
    },
    {
        ""English"":  ""to come up to"",
        ""Dothraki"":  ""jadilat""
    },
    {
        ""English"":  ""to command"",
        ""Dothraki"":  ""assolat""
    },
    {
        ""English"":  ""to compete"",
        ""Dothraki"":  ""lajilat""
    },
    {
        ""English"":  ""to conjoin"",
        ""Dothraki"":  ""kemat""
    },
    {
        ""English"":  ""to construct"",
        ""Dothraki"":  ""marilat""
    },
    {
        ""English"":  ""to contain"",
        ""Dothraki"":  ""loshat""
    },
    {
        ""English"":  ""to continue"",
        ""Dothraki"":  ""vatterat""
    },
    {
        ""English"":  ""to converse"",
        ""Dothraki"":  ""vasterat""
    },
    {
        ""English"":  ""to convey"",
        ""Dothraki"":  ""addothralat""
    },
    {
        ""English"":  ""to cook"",
        ""Dothraki"":  ""jolinat""
    },
    {
        ""English"":  ""to corral"",
        ""Dothraki"":  ""kadat""
    },
    {
        ""English"":  ""to count"",
        ""Dothraki"":  ""sanneyalat""
    },
    {
        ""English"":  ""to cover"",
        ""Dothraki"":  ""qemmolat""
    },
    {
        ""English"":  ""to create"",
        ""Dothraki"":  ""movelat""
    },
    {
        ""English"":  ""to cross"",
        ""Dothraki"":  ""yomat""
    },
    {
        ""English"":  ""to crush"",
        ""Dothraki"":  ""kaffat""
    },
    {
        ""English"":  ""to cry"",
        ""Dothraki"":  ""laqat""
    },
    {
        ""English"":  ""to cure"",
        ""Dothraki"":  ""kolat""
    },
    {
        ""English"":  ""to cut"",
        ""Dothraki"":  ""rissat""
    },
    {
        ""English"":  ""to cut into"",
        ""Dothraki"":  ""rissat""
    },
    {
        ""English"":  ""to cut off"",
        ""Dothraki"":  ""zirisselat""
    },
    {
        ""English"":  ""to dance"",
        ""Dothraki"":  ""ezhirat""
    },
    {
        ""English"":  ""to decide"",
        ""Dothraki"":  ""akkelenat""
    },
    {
        ""English"":  ""to decorate"",
        ""Dothraki"":  ""ammasat""
    },
    {
        ""English"":  ""to defeat"",
        ""Dothraki"":  ""assilat""
    },
    {
        ""English"":  ""to defeat"",
        ""Dothraki"":  ""atthasat""
    },
    {
        ""English"":  ""to defy"",
        ""Dothraki"":  ""ziganesolat""
    },
    {
        ""English"":  ""to destroy"",
        ""Dothraki"":  ""atthasat""
    },
    {
        ""English"":  ""to die"",
        ""Dothraki"":  ""drivolat""
    },
    {
        ""English"":  ""to die from"",
        ""Dothraki"":  ""drivolat""
    },
    {
        ""English"":  ""to dig"",
        ""Dothraki"":  ""hilelat""
    },
    {
        ""English"":  ""to disagree"",
        ""Dothraki"":  ""efichisalat""
    },
    {
        ""English"":  ""to disappoint"",
        ""Dothraki"":  ""lostat""
    },
    {
        ""English"":  ""to distract"",
        ""Dothraki"":  ""zimemelat""
    },
    {
        ""English"":  ""to divide"",
        ""Dothraki"":  ""sachat""
    },
    {
        ""English"":  ""to do"",
        ""Dothraki"":  ""tat""
    },
    {
        ""English"":  ""to domesticate a beast of burden"",
        ""Dothraki"":  ""vishaferat""
    },
    {
        ""English"":  ""to dream"",
        ""Dothraki"":  ""thirat atthiraride""
    },
    {
        ""English"":  ""to dress"",
        ""Dothraki"":  ""khogarat""
    },
    {
        ""English"":  ""to drink"",
        ""Dothraki"":  ""indelat""
    },
    {
        ""English"":  ""to drive"",
        ""Dothraki"":  ""drogat""
    },
    {
        ""English"":  ""to drop"",
        ""Dothraki"":  ""aranat""
    },
    {
        ""English"":  ""to dry"",
        ""Dothraki"":  ""atholat""
    },
    {
        ""English"":  ""to eat"",
        ""Dothraki"":  ""adakhat""
    },
    {
        ""English"":  ""to empty something"",
        ""Dothraki"":  ""ammenat""
    },
    {
        ""English"":  ""to encourage"",
        ""Dothraki"":  ""annithilat""
    },
    {
        ""English"":  ""to end"",
        ""Dothraki"":  ""nakholat""
    },
    {
        ""English"":  ""to enslave"",
        ""Dothraki"":  ""azzafrolat""
    },
    {
        ""English"":  ""to enter"",
        ""Dothraki"":  ""emralat""
    },
    {
        ""English"":  ""to entice"",
        ""Dothraki"":  ""annithilat""
    },
    {
        ""English"":  ""to exaggerate"",
        ""Dothraki"":  ""esittesalat""
    },
    {
        ""English"":  ""to examine"",
        ""Dothraki"":  ""vitiherat""
    },
    {
        ""English"":  ""to exist"",
        ""Dothraki"":  ""vekhat""
    },
    {
        ""English"":  ""to exit"",
        ""Dothraki"":  ""esemrasalat""
    },
    {
        ""English"":  ""to fail someone"",
        ""Dothraki"":  ""ziyenelat""
    },
    {
        ""English"":  ""to fall"",
        ""Dothraki"":  ""arthasat""
    },
    {
        ""English"":  ""to fear"",
        ""Dothraki"":  ""rokhat""
    },
    {
        ""English"":  ""to feel"",
        ""Dothraki"":  ""frakholat""
    },
    {
        ""English"":  ""to feel anxious"",
        ""Dothraki"":  ""gango awazat""
    },
    {
        ""English"":  ""to feel encouraged"",
        ""Dothraki"":  ""nithilat""
    },
    {
        ""English"":  ""to feel invigorated"",
        ""Dothraki"":  ""nithilat""
    },
    {
        ""English"":  ""to feel pain"",
        ""Dothraki"":  ""nithat""
    },
    {
        ""English"":  ""to feel pain from a specific source"",
        ""Dothraki"":  ""nithat""
    },
    {
        ""English"":  ""to ferment"",
        ""Dothraki"":  ""ohazholat""
    },
    {
        ""English"":  ""to fetch"",
        ""Dothraki"":  ""fichat""
    },
    {
        ""English"":  ""to fight"",
        ""Dothraki"":  ""lajat""
    },
    {
        ""English"":  ""to figure out"",
        ""Dothraki"":  ""gachat""
    },
    {
        ""English"":  ""to fill"",
        ""Dothraki"":  ""nirrat""
    },
    {
        ""English"":  ""to find"",
        ""Dothraki"":  ""ezat""
    },
    {
        ""English"":  ""to finish"",
        ""Dothraki"":  ""annakholat""
    },
    {
        ""English"":  ""to fix"",
        ""Dothraki"":  ""arrissat""
    },
    {
        ""English"":  ""to flash"",
        ""Dothraki"":  ""silat""
    },
    {
        ""English"":  ""to flinch"",
        ""Dothraki"":  ""yarat""
    },
    {
        ""English"":  ""to float"",
        ""Dothraki"":  ""qayelat""
    },
    {
        ""English"":  ""to flow"",
        ""Dothraki"":  ""vithalat""
    },
    {
        ""English"":  ""to fly"",
        ""Dothraki"":  ""ovethat""
    },
    {
        ""English"":  ""to follow"",
        ""Dothraki"":  ""sillat""
    },
    {
        ""English"":  ""to frighten"",
        ""Dothraki"":  ""arrokhat""
    },
    {
        ""English"":  ""to front of"",
        ""Dothraki"":  ""hatif""
    },
    {
        ""English"":  ""to frown"",
        ""Dothraki"":  ""nivat""
    },
    {
        ""English"":  ""to frustrate"",
        ""Dothraki"":  ""ahhaqat""
    },
    {
        ""English"":  ""to gallop"",
        ""Dothraki"":  ""karlinat""
    },
    {
        ""English"":  ""to gallop beside"",
        ""Dothraki"":  ""karlinat""
    },
    {
        ""English"":  ""to gallop fast enough to kill a horse"",
        ""Dothraki"":  ""karlinqoyi""
    },
    {
        ""English"":  ""to gather"",
        ""Dothraki"":  ""yanqolat""
    },
    {
        ""English"":  ""to gather"",
        ""Dothraki"":  ""yanqolat""
    },
    {
        ""English"":  ""to get ones’ first kill with a new weapon"",
        ""Dothraki"":  ""vishaferat""
    },
    {
        ""English"":  ""to get to know"",
        ""Dothraki"":  ""shilolat""
    },
    {
        ""English"":  ""to get up"",
        ""Dothraki"":  ""eshat""
    },
    {
        ""English"":  ""to give"",
        ""Dothraki"":  ""azhat""
    },
    {
        ""English"":  ""to give respect to"",
        ""Dothraki"":  ""chomolat""
    },
    {
        ""English"":  ""to give warmth to"",
        ""Dothraki"":  ""affazhat""
    },
    {
        ""English"":  ""to glance at"",
        ""Dothraki"":  ""tihilat""
    },
    {
        ""English"":  ""to gleam"",
        ""Dothraki"":  ""silat""
    },
    {
        ""English"":  ""to go"",
        ""Dothraki"":  ""elat""
    },
    {
        ""English"":  ""to go along with"",
        ""Dothraki"":  ""elat""
    },
    {
        ""English"":  ""to grow"",
        ""Dothraki"":  ""vitisherat""
    },
    {
        ""English"":  ""to grow fierce"",
        ""Dothraki"":  ""ivezholat""
    },
    {
        ""English"":  ""to grow hungry"",
        ""Dothraki"":  ""garvolat""
    },
    {
        ""English"":  ""to grow respectful"",
        ""Dothraki"":  ""avvitisherat""
    },
    {
        ""English"":  ""to grow strong"",
        ""Dothraki"":  ""hajolat""
    },
    {
        ""English"":  ""to grow tired"",
        ""Dothraki"":  ""haqolat""
    },
    {
        ""English"":  ""to guide"",
        ""Dothraki"":  ""idrilat""
    },
    {
        ""English"":  ""to harm someone"",
        ""Dothraki"":  ""azzisat""
    },
    {
        ""English"":  ""to hate"",
        ""Dothraki"":  ""fejat""
    },
    {
        ""English"":  ""to have"",
        ""Dothraki"":  ""ray""
    },
    {
        ""English"":  ""to have an erection"",
        ""Dothraki"":  ""dothralat""
    },
    {
        ""English"":  ""to have fur"",
        ""Dothraki"":  ""hemelat""
    },
    {
        ""English"":  ""to have sex"",
        ""Dothraki"":  ""hilelat""
    },
    {
        ""English"":  ""to heal"",
        ""Dothraki"":  ""kolat""
    },
    {
        ""English"":  ""to hear"",
        ""Dothraki"":  ""charat""
    },
    {
        ""English"":  ""to hear about"",
        ""Dothraki"":  ""charat""
    },
    {
        ""English"":  ""to hear some of"",
        ""Dothraki"":  ""charat""
    },
    {
        ""English"":  ""to help"",
        ""Dothraki"":  ""rhelalat""
    },
    {
        ""English"":  ""to hit at"",
        ""Dothraki"":  ""lojat""
    },
    {
        ""English"":  ""to hobble a person"",
        ""Dothraki"":  ""ammattelat""
    },
    {
        ""English"":  ""to hold"",
        ""Dothraki"":  ""qoralat""
    },
    {
        ""English"":  ""to honor"",
        ""Dothraki"":  ""chomolat""
    },
    {
        ""English"":  ""to hope for"",
        ""Dothraki"":  ""zalat""
    },
    {
        ""English"":  ""to hunger for"",
        ""Dothraki"":  ""garvolat""
    },
    {
        ""English"":  ""to hunt"",
        ""Dothraki"":  ""fonat""
    },
    {
        ""English"":  ""to hurt"",
        ""Dothraki"":  ""annithat""
    },
    {
        ""English"":  ""to imprison"",
        ""Dothraki"":  ""jervat""
    },
    {
        ""English"":  ""to insult"",
        ""Dothraki"":  ""fatilat""
    },
    {
        ""English"":  ""to introduce"",
        ""Dothraki"":  ""asshilat""
    },
    {
        ""English"":  ""to invigorate"",
        ""Dothraki"":  ""annithilat""
    },
    {
        ""English"":  ""to jog"",
        ""Dothraki"":  ""anat""
    },
    {
        ""English"":  ""to jog beside"",
        ""Dothraki"":  ""anat""
    },
    {
        ""English"":  ""to joke"",
        ""Dothraki"":  ""astilat""
    },
    {
        ""English"":  ""to joke about"",
        ""Dothraki"":  ""astilat""
    },
    {
        ""English"":  ""to jostle"",
        ""Dothraki"":  ""zireyeselat""
    },
    {
        ""English"":  ""to judge"",
        ""Dothraki"":  ""akkelenat""
    },
    {
        ""English"":  ""to jump over"",
        ""Dothraki"":  ""shokat""
    },
    {
        ""English"":  ""to keep near"",
        ""Dothraki"":  ""aqqisat""
    },
    {
        ""English"":  ""to kick"",
        ""Dothraki"":  ""fakat""
    },
    {
        ""English"":  ""to kick at"",
        ""Dothraki"":  ""fakat""
    },
    {
        ""English"":  ""to kill"",
        ""Dothraki"":  ""addrivat""
    },
    {
        ""English"":  ""to kiss"",
        ""Dothraki"":  ""zoqwat""
    },
    {
        ""English"":  ""to know"",
        ""Dothraki"":  ""shilat""
    },
    {
        ""English"":  ""to know how"",
        ""Dothraki"":  ""devolat""
    },
    {
        ""English"":  ""to lack"",
        ""Dothraki"":  ""gerat""
    },
    {
        ""English"":  ""to last"",
        ""Dothraki"":  ""kashat""
    },
    {
        ""English"":  ""to laugh"",
        ""Dothraki"":  ""jasat""
    },
    {
        ""English"":  ""to leak"",
        ""Dothraki"":  ""thimalat""
    },
    {
        ""English"":  ""to lean"",
        ""Dothraki"":  ""ganat""
    },
    {
        ""English"":  ""to leap"",
        ""Dothraki"":  ""vrelat""
    },
    {
        ""English"":  ""to learn"",
        ""Dothraki"":  ""nesolat""
    },
    {
        ""English"":  ""to leave something alone"",
        ""Dothraki"":  ""annevalat""
    },
    {
        ""English"":  ""to leave"",
        ""Dothraki"":  ""esemrasalat""
    },
    {
        ""English"":  ""to let go of"",
        ""Dothraki"":  ""eqorasalat""
    },
    {
        ""English"":  ""to lie down"",
        ""Dothraki"":  ""chilat""
    },
    {
        ""English"":  ""to lift"",
        ""Dothraki"":  ""ayyathat""
    },
    {
        ""English"":  ""to limp"",
        ""Dothraki"":  ""mattelat""
    },
    {
        ""English"":  ""to listen"",
        ""Dothraki"":  ""charolat""
    },
    {
        ""English"":  ""to live"",
        ""Dothraki"":  ""thirat""
    },
    {
        ""English"":  ""to load"",
        ""Dothraki"":  ""moskat""
    },
    {
        ""English"":  ""to look at"",
        ""Dothraki"":  ""tihilat""
    },
    {
        ""English"":  ""to look upon"",
        ""Dothraki"":  ""vitiherat""
    },
    {
        ""English"":  ""to look"",
        ""Dothraki"":  ""tihat""
    },
    {
        ""English"":  ""to love someone"",
        ""Dothraki"":  ""zhilat""
    },
    {
        ""English"":  ""to make a sound"",
        ""Dothraki"":  ""memat""
    },
    {
        ""English"":  ""to make by hand"",
        ""Dothraki"":  ""movelat""
    },
    {
        ""English"":  ""to make distance"",
        ""Dothraki"":  ""hezhahat""
    },
    {
        ""English"":  ""to make hot"",
        ""Dothraki"":  ""affazhat""
    },
    {
        ""English"":  ""to make someone drink"",
        ""Dothraki"":  ""iddelat""
    },
    {
        ""English"":  ""to make someone itch"",
        ""Dothraki"":  ""affesat""
    },
    {
        ""English"":  ""to make someone walk"",
        ""Dothraki"":  ""iffat""
    },
    {
        ""English"":  ""to make someone fall"",
        ""Dothraki"":  ""atthasat""
    },
    {
        ""English"":  ""to make something enter"",
        ""Dothraki"":  ""emmalat""
    },
    {
        ""English"":  ""to make something to kneel"",
        ""Dothraki"":  ""avvemolat""
    },
    {
        ""English"":  ""to make something well-proven"",
        ""Dothraki"":  ""ittelat""
    },
    {
        ""English"":  ""to manage to"",
        ""Dothraki"":  ""vil""
    },
    {
        ""English"":  ""to mark"",
        ""Dothraki"":  ""sholat""
    },
    {
        ""English"":  ""to marry"",
        ""Dothraki"":  ""kemat""
    },
    {
        ""English"":  ""to marry someone"",
        ""Dothraki"":  ""kemolatprecede""
    },
    {
        ""English"":  ""to mate"",
        ""Dothraki"":  ""govat""
    },
    {
        ""English"":  ""to meet"",
        ""Dothraki"":  ""shilolat""
    },
    {
        ""English"":  ""to melt"",
        ""Dothraki"":  ""ivisat""
    },
    {
        ""English"":  ""to melt something"",
        ""Dothraki"":  ""ivvisat""
    },
    {
        ""English"":  ""to miss"",
        ""Dothraki"":  ""lostat""
    },
    {
        ""English"":  ""to miss someone"",
        ""Dothraki"":  ""vigererat""
    },
    {
        ""English"":  ""to mount"",
        ""Dothraki"":  ""sajat""
    },
    {
        ""English"":  ""to move like a caterpillar"",
        ""Dothraki"":  ""filkat""
    },
    {
        ""English"":  ""to move something"",
        ""Dothraki"":  ""eyelat""
    },
    {
        ""English"":  ""to move weakly"",
        ""Dothraki"":  ""havolat""
    },
    {
        ""English"":  ""to name something"",
        ""Dothraki"":  ""hakelat""
    },
    {
        ""English"":  ""to navigate"",
        ""Dothraki"":  ""hezhahat""
    },
    {
        ""English"":  ""to need"",
        ""Dothraki"":  ""zigerelat""
    },
    {
        ""English"":  ""to observe"",
        ""Dothraki"":  ""vitihirat""
    },
    {
        ""English"":  ""to offend"",
        ""Dothraki"":  ""zireyeselat""
    },
    {
        ""English"":  ""to oppose"",
        ""Dothraki"":  ""ziganesolat""
    },
    {
        ""English"":  ""to pack"",
        ""Dothraki"":  ""moskat""
    },
    {
        ""English"":  ""to pass"",
        ""Dothraki"":  ""dinat""
    },
    {
        ""English"":  ""to plant"",
        ""Dothraki"":  ""elainat""
    },
    {
        ""English"":  ""to play a musical instrument"",
        ""Dothraki"":  ""ammemat""
    },
    {
        ""English"":  ""to play"",
        ""Dothraki"":  ""lajilat""
    },
    {
        ""English"":  ""to plead"",
        ""Dothraki"":  ""viqaferat""
    },
    {
        ""English"":  ""to please"",
        ""Dothraki"":  ""allayafat""
    },
    {
        ""English"":  ""to pledge"",
        ""Dothraki"":  ""alloshat""
    },
    {
        ""English"":  ""to point"",
        ""Dothraki"":  ""tirat""
    },
    {
        ""English"":  ""to poison"",
        ""Dothraki"":  ""izzat""
    },
    {
        ""English"":  ""to ponder"",
        ""Dothraki"":  ""vitiherat""
    },
    {
        ""English"":  ""to practice woman-on-top sex"",
        ""Dothraki"":  ""ijelat""
    },
    {
        ""English"":  ""to present"",
        ""Dothraki"":  ""asshilat""
    },
    {
        ""English"":  ""to procrastinate"",
        ""Dothraki"":  ""velzerat""
    },
    {
        ""English"":  ""to protect"",
        ""Dothraki"":  ""vijazerat""
    },
    {
        ""English"":  ""to pry something off of something else"",
        ""Dothraki"":  ""vefenarat""
    },
    {
        ""English"":  ""to pull"",
        ""Dothraki"":  ""jesat""
    },
    {
        ""English"":  ""to pull with both hands"",
        ""Dothraki"":  ""kartat""
    },
    {
        ""English"":  ""to pull with other means than with arms"",
        ""Dothraki"":  ""kartolat""
    },
    {
        ""English"":  ""to push"",
        ""Dothraki"":  ""gidat""
    },
    {
        ""English"":  ""to put an end to"",
        ""Dothraki"":  ""to finish""
    },
    {
        ""English"":  ""to put something down"",
        ""Dothraki"":  ""azzohat""
    },
    {
        ""English"":  ""to rape"",
        ""Dothraki"":  ""qorasolat""
    },
    {
        ""English"":  ""to reach to touch"",
        ""Dothraki"":  ""frakhat""
    },
    {
        ""English"":  ""to refuse to"",
        ""Dothraki"":  ""zajjat""
    },
    {
        ""English"":  ""to rein"",
        ""Dothraki"":  ""javrathat""
    },
    {
        ""English"":  ""to remember"",
        ""Dothraki"":  ""vineserat""
    },
    {
        ""English"":  ""to remove"",
        ""Dothraki"":  ""ejervalat""
    },
    {
        ""English"":  ""to remove"",
        ""Dothraki"":  ""zirisselat""
    },
    {
        ""English"":  ""to replace"",
        ""Dothraki"":  ""affazolat""
    },
    {
        ""English"":  ""to require"",
        ""Dothraki"":  ""zigerelat""
    },
    {
        ""English"":  ""to rescue"",
        ""Dothraki"":  ""vijazerolat""
    },
    {
        ""English"":  ""to respect"",
        ""Dothraki"":  ""chomat""
    },
    {
        ""English"":  ""to respond"",
        ""Dothraki"":  ""elzat""
    },
    {
        ""English"":  ""to rest"",
        ""Dothraki"":  ""ammithrat""
    },
    {
        ""English"":  ""to retch"",
        ""Dothraki"":  ""ziqwehelat""
    },
    {
        ""English"":  ""to return"",
        ""Dothraki"":  ""essalat""
    },
    {
        ""English"":  ""to ricochet"",
        ""Dothraki"":  ""jekhtat""
    },
    {
        ""English"":  ""to ride"",
        ""Dothraki"":  ""dothralat""
    },
    {
        ""English"":  ""to ride alongside"",
        ""Dothraki"":  ""dothralat""
    },
    {
        ""English"":  ""to ring"",
        ""Dothraki"":  ""okhat""
    },
    {
        ""English"":  ""to rip something"",
        ""Dothraki"":  ""aggendat""
    },
    {
        ""English"":  ""to rip"",
        ""Dothraki"":  ""gendolat""
    },
    {
        ""English"":  ""to rise"",
        ""Dothraki"":  ""yatholat""
    },
    {
        ""English"":  ""to roar"",
        ""Dothraki"":  ""zorat""
    },
    {
        ""English"":  ""to roll"",
        ""Dothraki"":  ""chorkat""
    },
    {
        ""English"":  ""to rot"",
        ""Dothraki"":  ""rikholat""
    },
    {
        ""English"":  ""to rub"",
        ""Dothraki"":  ""oldat""
    },
    {
        ""English"":  ""to run"",
        ""Dothraki"":  ""lanat""
    },
    {
        ""English"":  ""to run beside"",
        ""Dothraki"":  ""lanat""
    },
    {
        ""English"":  ""to run off"",
        ""Dothraki"":  ""lojat""
    },
    {
        ""English"":  ""to save"",
        ""Dothraki"":  ""vijazerolat""
    },
    {
        ""English"":  ""to say"",
        ""Dothraki"":  ""astat""
    },
    {
        ""English"":  ""to scrape"",
        ""Dothraki"":  ""rochat""
    },
    {
        ""English"":  ""to scratch"",
        ""Dothraki"":  ""efesalat""
    },
    {
        ""English"":  ""to scream"",
        ""Dothraki"":  ""awazat""
    },
    {
        ""English"":  ""to see"",
        ""Dothraki"":  ""tihat""
    },
    {
        ""English"":  ""to seek"",
        ""Dothraki"":  ""fonolat""
    },
    {
        ""English"":  ""to seize"",
        ""Dothraki"":  ""qoralat""
    },
    {
        ""English"":  ""to sew"",
        ""Dothraki"":  ""madat""
    },
    {
        ""English"":  ""to shame"",
        ""Dothraki"":  ""arranat""
    },
    {
        ""English"":  ""to sharpen"",
        ""Dothraki"":  ""ahhasat""
    },
    {
        ""English"":  ""to shed"",
        ""Dothraki"":  ""qovvolat""
    },
    {
        ""English"":  ""to shiver"",
        ""Dothraki"":  ""vichiterat""
    },
    {
        ""English"":  ""to shoot"",
        ""Dothraki"":  ""ovvethat""
    },
    {
        ""English"":  ""to shout"",
        ""Dothraki"":  ""donat""
    },
    {
        ""English"":  ""to shout about"",
        ""Dothraki"":  ""donat""
    },
    {
        ""English"":  ""to show"",
        ""Dothraki"":  ""attihat""
    },
    {
        ""English"":  ""to signal"",
        ""Dothraki"":  ""assilat""
    },
    {
        ""English"":  ""to signal to"",
        ""Dothraki"":  ""assilat""
    },
    {
        ""English"":  ""to silence"",
        ""Dothraki"":  ""acchakat""
    },
    {
        ""English"":  ""to sing"",
        ""Dothraki"":  ""hoyalat""
    },
    {
        ""English"":  ""to sit"",
        ""Dothraki"":  ""nevalat""
    },
    {
        ""English"":  ""to sit down"",
        ""Dothraki"":  ""nevasolat""
    },
    {
        ""English"":  ""to sit something"",
        ""Dothraki"":  ""annevalat""
    },
    {
        ""English"":  ""to slap"",
        ""Dothraki"":  ""fatat""
    },
    {
        ""English"":  ""to slap at"",
        ""Dothraki"":  ""fatat""
    },
    {
        ""English"":  ""to slaughter an animal"",
        ""Dothraki"":  ""ogat""
    },
    {
        ""English"":  ""to slay"",
        ""Dothraki"":  ""drozhat""
    },
    {
        ""English"":  ""to sleep"",
        ""Dothraki"":  ""remekat""
    },
    {
        ""English"":  ""to smash"",
        ""Dothraki"":  ""kafat""
    },
    {
        ""English"":  ""to smell"",
        ""Dothraki"":  ""rivvat""
    },
    {
        ""English"":  ""to smile"",
        ""Dothraki"":  ""emat""
    },
    {
        ""English"":  ""to smile at"",
        ""Dothraki"":  ""emat""
    },
    {
        ""English"":  ""to sneeze"",
        ""Dothraki"":  ""khefat""
    },
    {
        ""English"":  ""to sniff"",
        ""Dothraki"":  ""rivvat""
    },
    {
        ""English"":  ""to snore"",
        ""Dothraki"":  ""shigat""
    },
    {
        ""English"":  ""to solidify"",
        ""Dothraki"":  ""chongolat""
    },
    {
        ""English"":  ""to solve"",
        ""Dothraki"":  ""gachat""
    },
    {
        ""English"":  ""to sound rythmically"",
        ""Dothraki"":  ""oqolat""
    },
    {
        ""English"":  ""to sow"",
        ""Dothraki"":  ""velainerat""
    },
    {
        ""English"":  ""to spar"",
        ""Dothraki"":  ""lajilat""
    },
    {
        ""English"":  ""to speak"",
        ""Dothraki"":  ""astolat""
    },
    {
        ""English"":  ""to speak of"",
        ""Dothraki"":  ""astolat""
    },
    {
        ""English"":  ""to speak with"",
        ""Dothraki"":  ""vasterat""
    },
    {
        ""English"":  ""to spill"",
        ""Dothraki"":  ""addrekat""
    },
    {
        ""English"":  ""to spit"",
        ""Dothraki"":  ""sikhtelat""
    },
    {
        ""English"":  ""to squeeze"",
        ""Dothraki"":  ""efat""
    },
    {
        ""English"":  ""to stab"",
        ""Dothraki"":  ""vindelat""
    },
    {
        ""English"":  ""to stab at"",
        ""Dothraki"":  ""vindelat""
    },
    {
        ""English"":  ""to stall"",
        ""Dothraki"":  ""velzerat""
    },
    {
        ""English"":  ""to stand"",
        ""Dothraki"":  ""kovarat""
    },
    {
        ""English"":  ""to stand up"",
        ""Dothraki"":  ""akkovarat""
    },
    {
        ""English"":  ""to stare at"",
        ""Dothraki"":  ""vitiherat""
    },
    {
        ""English"":  ""to start"",
        ""Dothraki"":  ""evolat""
    },
    {
        ""English"":  ""to start doing something"",
        ""Dothraki"":  ""evat""
    },
    {
        ""English"":  ""to start something"",
        ""Dothraki"":  ""evvat""
    },
    {
        ""English"":  ""to stay"",
        ""Dothraki"":  ""vikovarerat""
    },
    {
        ""English"":  ""to steal"",
        ""Dothraki"":  ""zifichelat""
    },
    {
        ""English"":  ""to stop"",
        ""Dothraki"":  ""nakhat""
    },
    {
        ""English"":  ""to strike"",
        ""Dothraki"":  ""ildat""
    },
    {
        ""English"":  ""to suck"",
        ""Dothraki"":  ""oshat""
    },
    {
        ""English"":  ""to suddenly turn completely around"",
        ""Dothraki"":  ""idirolat""
    },
    {
        ""English"":  ""to suffer"",
        ""Dothraki"":  ""dogat""
    },
    {
        ""English"":  ""to suffer from"",
        ""Dothraki"":  ""dogat""
    },
    {
        ""English"":  ""to surpass"",
        ""Dothraki"":  ""samvenolat""
    },
    {
        ""English"":  ""to survive"",
        ""Dothraki"":  ""thirolat""
    },
    {
        ""English"":  ""to swallow"",
        ""Dothraki"":  ""ijelat""
    },
    {
        ""English"":  ""to swell"",
        ""Dothraki"":  ""mesolat""
    },
    {
        ""English"":  ""to swim"",
        ""Dothraki"":  ""zerqolat""
    },
    {
        ""English"":  ""to take a little pee"",
        ""Dothraki"":  ""navilat""
    },
    {
        ""English"":  ""to take something back"",
        ""Dothraki"":  ""esazhalat""
    },
    {
        ""English"":  ""to take"",
        ""Dothraki"":  ""fichat""
    },
    {
        ""English"":  ""to take"",
        ""Dothraki"":  ""qorasolat""
    },
    {
        ""English"":  ""to taste"",
        ""Dothraki"":  ""lekhilat""
    },
    {
        ""English"":  ""to tattoo"",
        ""Dothraki"":  ""lirat""
    },
    {
        ""English"":  ""to teach"",
        ""Dothraki"":  ""ezzolat""
    },
    {
        ""English"":  ""to tear down"",
        ""Dothraki"":  ""ohharat""
    },
    {
        ""English"":  ""to tear something"",
        ""Dothraki"":  ""aggendat""
    },
    {
        ""English"":  ""to test in action"",
        ""Dothraki"":  ""ittelat""
    },
    {
        ""English"":  ""to think"",
        ""Dothraki"":  ""dirgat""
    },
    {
        ""English"":  ""to thirst"",
        ""Dothraki"":  ""fevelat""
    },
    {
        ""English"":  ""to thirst for"",
        ""Dothraki"":  ""fevelat""
    },
    {
        ""English"":  ""to throw an insult at"",
        ""Dothraki"":  ""fatilat""
    },
    {
        ""English"":  ""to throw"",
        ""Dothraki"":  ""ovvethat""
    },
    {
        ""English"":  ""to tie"",
        ""Dothraki"":  ""liwalat""
    },
    {
        ""English"":  ""to tip over and spill"",
        ""Dothraki"":  ""drekolat""
    },
    {
        ""English"":  ""to touch"",
        ""Dothraki"":  ""frakhat""
    },
    {
        ""English"":  ""to track"",
        ""Dothraki"":  ""fonolat""
    },
    {
        ""English"":  ""to trade"",
        ""Dothraki"":  ""jerat""
    },
    {
        ""English"":  ""to train"",
        ""Dothraki"":  ""lajilat""
    },
    {
        ""English"":  ""to trample"",
        ""Dothraki"":  ""nokittat""
    },
    {
        ""English"":  ""to transport someone"",
        ""Dothraki"":  ""addothralat""
    },
    {
        ""English"":  ""to travel"",
        ""Dothraki"":  ""verat""
    },
    {
        ""English"":  ""to travel"",
        ""Dothraki"":  ""hezhahat""
    },
    {
        ""English"":  ""to tremble"",
        ""Dothraki"":  ""qovat""
    },
    {
        ""English"":  ""to trot"",
        ""Dothraki"":  ""irvosat""
    },
    {
        ""English"":  ""to trust"",
        ""Dothraki"":  ""shillat""
    },
    {
        ""English"":  ""to try to"",
        ""Dothraki"":  ""kis""
    },
    {
        ""English"":  ""to turn"",
        ""Dothraki"":  ""notat""
    },
    {
        ""English"":  ""to understand"",
        ""Dothraki"":  ""tiholat""
    },
    {
        ""English"":  ""to undress"",
        ""Dothraki"":  ""ekhogaralat""
    },
    {
        ""English"":  ""to uproot"",
        ""Dothraki"":  ""efesalat""
    },
    {
        ""English"":  ""to urinate"",
        ""Dothraki"":  ""navat""
    },
    {
        ""English"":  ""to vomit"",
        ""Dothraki"":  ""qwehat""
    },
    {
        ""English"":  ""to wait"",
        ""Dothraki"":  ""ayolat""
    },
    {
        ""English"":  ""to walk"",
        ""Dothraki"":  ""ifat""
    },
    {
        ""English"":  ""to walk beside"",
        ""Dothraki"":  ""ifat""
    },
    {
        ""English"":  ""to want"",
        ""Dothraki"":  ""zalat""
    },
    {
        ""English"":  ""to warm"",
        ""Dothraki"":  ""affazhat""
    },
    {
        ""English"":  ""to wash"",
        ""Dothraki"":  ""affisat""
    },
    {
        ""English"":  ""to watch"",
        ""Dothraki"":  ""vitihirat""
    },
    {
        ""English"":  ""to wear"",
        ""Dothraki"":  ""ondelat""
    },
    {
        ""English"":  ""to weave"",
        ""Dothraki"":  ""soqat""
    },
    {
        ""English"":  ""to weep"",
        ""Dothraki"":  ""laqat""
    },
    {
        ""English"":  ""to welcome"",
        ""Dothraki"":  ""iddelat""
    },
    {
        ""English"":  ""to where"",
        ""Dothraki"":  ""rekkaan""
    },
    {
        ""English"":  ""to wink"",
        ""Dothraki"":  ""lorat""
    },
    {
        ""English"":  ""to wipe"",
        ""Dothraki"":  ""nofilat""
    },
    {
        ""English"":  ""to wrangle"",
        ""Dothraki"":  ""kadat""
    },
    {
        ""English"":  ""today"",
        ""Dothraki"":  ""asshekh""
    },
    {
        ""English"":  ""together"",
        ""Dothraki"":  ""niyanqoy""
    },
    {
        ""English"":  ""tomorrow"",
        ""Dothraki"":  ""silokh""
    },
    {
        ""English"":  ""tongue"",
        ""Dothraki"":  ""lekh""
    },
    {
        ""English"":  ""tonight"",
        ""Dothraki"":  ""ajjalan""
    },
    {
        ""English"":  ""too much"",
        ""Dothraki"":  ""sekke""
    },
    {
        ""English"":  ""too"",
        ""Dothraki"":  ""akka""
    },
    {
        ""English"":  ""tool"",
        ""Dothraki"":  ""marriya""
    },
    {
        ""English"":  ""tooth"",
        ""Dothraki"":  ""vorto""
    },
    {
        ""English"":  ""top part"",
        ""Dothraki"":  ""essheya""
    },
    {
        ""English"":  ""top"",
        ""Dothraki"":  ""essheya""
    },
    {
        ""English"":  ""topic"",
        ""Dothraki"":  ""aranikh""
    },
    {
        ""English"":  ""total lunar eclipse"",
        ""Dothraki"":  ""jalanqoyi""
    },
    {
        ""English"":  ""total solar eclipse"",
        ""Dothraki"":  ""shekhqoyi""
    },
    {
        ""English"":  ""totally"",
        ""Dothraki"":  ""nakhaan""
    },
    {
        ""English"":  ""trader’s guild"",
        ""Dothraki"":  ""jerakasar""
    },
    {
        ""English"":  ""trader"",
        ""Dothraki"":  ""jerak""
    },
    {
        ""English"":  ""traitor"",
        ""Dothraki"":  ""chafak""
    },
    {
        ""English"":  ""trap"",
        ""Dothraki"":  ""orzo""
    },
    {
        ""English"":  ""trap"",
        ""Dothraki"":  ""qosarvenikh""
    },
    {
        ""English"":  ""traveler"",
        ""Dothraki"":  ""verak""
    },
    {
        ""English"":  ""tree"",
        ""Dothraki"":  ""feshith""
    },
    {
        ""English"":  ""tree that can blossom"",
        ""Dothraki"":  ""halahi""
    },
    {
        ""English"":  ""trembling"",
        ""Dothraki"":  ""qov""
    },
    {
        ""English"":  ""trout"",
        ""Dothraki"":  ""irra""
    },
    {
        ""English"":  ""trunk"",
        ""Dothraki"":  ""khogari""
    },
    {
        ""English"":  ""trustee"",
        ""Dothraki"":  ""okeo""
    },
    {
        ""English"":  ""turncloak"",
        ""Dothraki"":  ""chafak""
    },
    {
        ""English"":  ""turnip"",
        ""Dothraki"":  ""vado""
    },
    {
        ""English"":  ""turtle"",
        ""Dothraki"":  ""adra""
    },
    {
        ""English"":  ""tweet"",
        ""Dothraki"":  ""memziri""
    },
    {
        ""English"":  ""twelve"",
        ""Dothraki"":  ""akatthi""
    },
    {
        ""English"":  ""twenty"",
        ""Dothraki"":  ""chakat""
    },
    {
        ""English"":  ""two"",
        ""Dothraki"":  ""akat""
    },
    {
        ""English"":  ""two hundred"",
        ""Dothraki"":  ""akatken""
    },
    {
        ""English"":  ""type of grass"",
        ""Dothraki"":  ""dahana""
    },
    {
        ""English"":  ""ultimately"",
        ""Dothraki"":  ""nakhaan""
    },
    {
        ""English"":  ""under"",
        ""Dothraki"":  ""torga""
    },
    {
        ""English"":  ""untamed captured animal"",
        ""Dothraki"":  ""kadikh""
    },
    {
        ""English"":  ""until"",
        ""Dothraki"":  ""kash""
    },
    {
        ""English"":  ""up"",
        ""Dothraki"":  ""yath""
    },
    {
        ""English"":  ""update"",
        ""Dothraki"":  ""flasikh""
    },
    {
        ""English"":  ""upon"",
        ""Dothraki"":  ""she""
    },
    {
        ""English"":  ""upward"",
        ""Dothraki"":  ""yath""
    },
    {
        ""English"":  ""upwards"",
        ""Dothraki"":  ""yath""
    },
    {
        ""English"":  ""useful thing"",
        ""Dothraki"":  ""davrakh""
    },
    {
        ""English"":  ""useful"",
        ""Dothraki"":  ""davra""
    },
    {
        ""English"":  ""usefullness"",
        ""Dothraki"":  ""athdavrazar""
    },
    {
        ""English"":  ""useless"",
        ""Dothraki"":  ""edavrasa""
    },
    {
        ""English"":  ""valuable"",
        ""Dothraki"":  ""mas""
    },
    {
        ""English"":  ""vegetable"",
        ""Dothraki"":  ""ilme""
    },
    {
        ""English"":  ""vegetables"",
        ""Dothraki"":  ""ilmeser""
    },
    {
        ""English"":  ""verb"",
        ""Dothraki"":  ""tikkheya""
    },
    {
        ""English"":  ""very simple"",
        ""Dothraki"":  ""disisse""
    },
    {
        ""English"":  ""very well"",
        ""Dothraki"":  ""chekosshi""
    },
    {
        ""English"":  ""very"",
        ""Dothraki"":  ""serja""
    },
    {
        ""English"":  ""victorious"",
        ""Dothraki"":  ""najah""
    },
    {
        ""English"":  ""victory"",
        ""Dothraki"":  ""iffi""
    },
    {
        ""English"":  ""victory"",
        ""Dothraki"":  ""najaheya""
    },
    {
        ""English"":  ""view"",
        ""Dothraki"":  ""tihikh""
    },
    {
        ""English"":  ""violent"",
        ""Dothraki"":  ""verven""
    },
    {
        ""English"":  ""vision"",
        ""Dothraki"":  ""athtihar""
    },
    {
        ""English"":  ""vocative marker"",
        ""Dothraki"":  ""zhey""
    },
    {
        ""English"":  ""vow"",
        ""Dothraki"":  ""asqoyi""
    },
    {
        ""English"":  ""vulnerability"",
        ""Dothraki"":  ""ovrakh""
    },
    {
        ""English"":  ""vulture"",
        ""Dothraki"":  ""jadro""
    },
    {
        ""English"":  ""wailing"",
        ""Dothraki"":  ""athlaqar""
    },
    {
        ""English"":  ""waist"",
        ""Dothraki"":  ""khaor""
    },
    {
        ""English"":  ""waiting"",
        ""Dothraki"":  ""athayozar""
    },
    {
        ""English"":  ""wall"",
        ""Dothraki"":  ""gref""
    },
    {
        ""English"":  ""war"",
        ""Dothraki"":  ""athvilajerar""
    },
    {
        ""English"":  ""warlock"",
        ""Dothraki"":  ""movek""
    },
    {
        ""English"":  ""warm"",
        ""Dothraki"":  ""lajak""
    },
    {
        ""English"":  ""waste"",
        ""Dothraki"":  ""graddakh""
    },
    {
        ""English"":  ""wasteland"",
        ""Dothraki"":  ""athasar""
    },
    {
        ""English"":  ""watch"",
        ""Dothraki"":  ""vitihirak""
    },
    {
        ""English"":  ""water"",
        ""Dothraki"":  ""eveth""
    },
    {
        ""English"":  ""we"",
        ""Dothraki"":  ""kisha""
    },
    {
        ""English"":  ""weak hit"",
        ""Dothraki"":  ""chiftikh""
    },
    {
        ""English"":  ""weapon"",
        ""Dothraki"":  ""vov""
    },
    {
        ""English"":  ""weather"",
        ""Dothraki"":  ""gillosor""
    },
    {
        ""English"":  ""weighted net"",
        ""Dothraki"":  ""kathqoyi""
    },
    {
        ""English"":  ""well"",
        ""Dothraki"":  ""chek""
    },
    {
        ""English"":  ""well proven"",
        ""Dothraki"":  ""iste""
    },
    {
        ""English"":  ""well tested"",
        ""Dothraki"":  ""iste""
    },
    {
        ""English"":  ""west"",
        ""Dothraki"":  ""jimma""
    },
    {
        ""English"":  ""western"",
        ""Dothraki"":  ""jim""
    },
    {
        ""English"":  ""wet"",
        ""Dothraki"":  ""diwe""
    },
    {
        ""English"":  ""what"",
        ""Dothraki"":  ""fin""
    },
    {
        ""English"":  ""when"",
        ""Dothraki"":  ""affin""
    },
    {
        ""English"":  ""where"",
        ""Dothraki"":  ""finne""
    },
    {
        ""English"":  ""while"",
        ""Dothraki"":  ""kash""
    },
    {
        ""English"":  ""whip"",
        ""Dothraki"":  ""orvik""
    },
    {
        ""English"":  ""white"",
        ""Dothraki"":  ""zasqa""
    },
    {
        ""English"":  ""white lion"",
        ""Dothraki"":  ""hrakkar""
    },
    {
        ""English"":  ""who"",
        ""Dothraki"":  ""fin""
    },
    {
        ""English"":  ""whoa!"",
        ""Dothraki"":  ""affa""
    },
    {
        ""English"":  ""whore"",
        ""Dothraki"":  ""mezhah""
    },
    {
        ""English"":  ""why"",
        ""Dothraki"":  ""kirekhdirgi""
    },
    {
        ""English"":  ""wide"",
        ""Dothraki"":  ""ovah""
    },
    {
        ""English"":  ""wife"",
        ""Dothraki"":  ""chiorikem""
    },
    {
        ""English"":  ""wife of a khal"",
        ""Dothraki"":  ""khaleesi""
    },
    {
        ""English"":  ""wild"",
        ""Dothraki"":  ""ivezh""
    },
    {
        ""English"":  ""wind"",
        ""Dothraki"":  ""chaf""
    },
    {
        ""English"":  ""wine"",
        ""Dothraki"":  ""sewafikh""
    },
    {
        ""English"":  ""wine merchant"",
        ""Dothraki"":  ""jerak sewafikhaan""
    },
    {
        ""English"":  ""wing"",
        ""Dothraki"":  ""felde""
    },
    {
        ""English"":  ""winner"",
        ""Dothraki"":  ""najahak""
    },
    {
        ""English"":  ""winter"",
        ""Dothraki"":  ""aheshke""
    },
    {
        ""English"":  ""wisdom"",
        ""Dothraki"":  ""athvillar""
    },
    {
        ""English"":  ""wise"",
        ""Dothraki"":  ""ville""
    },
    {
        ""English"":  ""witch"",
        ""Dothraki"":  ""maegi""
    },
    {
        ""English"":  ""with"",
        ""Dothraki"":  ""ma""
    },
    {
        ""English"":  ""with respect"",
        ""Dothraki"":  ""m’athchomaroon""
    },
    {
        ""English"":  ""within"",
        ""Dothraki"":  ""mra""
    },
    {
        ""English"":  ""without"",
        ""Dothraki"":  ""oma""
    },
    {
        ""English"":  ""wolf"",
        ""Dothraki"":  ""ver""
    },
    {
        ""English"":  ""woman"",
        ""Dothraki"":  ""chiori""
    },
    {
        ""English"":  ""woman-on-top sex"",
        ""Dothraki"":  ""athijezar""
    },
    {
        ""English"":  ""wooden"",
        ""Dothraki"":  ""ido""
    },
    {
        ""English"":  ""wool"",
        ""Dothraki"":  ""vafikh""
    },
    {
        ""English"":  ""word for one’s apparel"",
        ""Dothraki"":  ""khogar""
    },
    {
        ""English"":  ""world"",
        ""Dothraki"":  ""rhaesheser""
    },
    {
        ""English"":  ""worm"",
        ""Dothraki"":  ""khewo""
    },
    {
        ""English"":  ""wound"",
        ""Dothraki"":  ""ziso""
    },
    {
        ""English"":  ""wrist"",
        ""Dothraki"":  ""hlofa""
    },
    {
        ""English"":  ""wrong"",
        ""Dothraki"":  ""oji""
    },
    {
        ""English"":  ""yak"",
        ""Dothraki"":  ""hammi""
    },
    {
        ""English"":  ""yam"",
        ""Dothraki"":  ""oeta""
    },
    {
        ""English"":  ""year"",
        ""Dothraki"":  ""firesof""
    },
    {
        ""English"":  ""yellow"",
        ""Dothraki"":  ""veltor""
    },
    {
        ""English"":  ""yes"",
        ""Dothraki"":  ""sek""
    },
    {
        ""English"":  ""yesterday"",
        ""Dothraki"":  ""oskikh""
    },
    {
        ""English"":  ""yogurt made from mare’s milk"",
        ""Dothraki"":  ""thagwa""
    },
    {
        ""English"":  ""you"",
        ""Dothraki"":  ""yer""
    },
    {
        ""English"":  ""young"",
        ""Dothraki"":  ""imesh""
    },
    {
        ""English"":  ""young goat"",
        ""Dothraki"":  """"
    },
    {
        ""English"":  ""young male horse"",
        ""Dothraki"":  ""manin""
    },
    {
        ""English"":  ""your"",
        ""Dothraki"":  ""yeri""
    },
    {
        ""English"":  ""youth"",
        ""Dothraki"":  ""yamori""
    },
    {
        ""English"":  ""zero"",
        ""Dothraki"":  ""som""
    }
]
";
    }
}
                                       