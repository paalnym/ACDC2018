import * as React from "react";
import { IDothrakiMicProps } from "./IDothrakiMicProps";
import { IDothrakiMicState } from "./IDothrakiMicState";
import { DefaultButton, Label, IconButton, IButtonProps } from 'office-ui-fabric-react/lib';
import * as SDK from 'microsoft-speech-browser-sdk';

export default class DothrakiMic extends React.Component<IDothrakiMicProps, IDothrakiMicState> {
  constructor(props) {
      super(props);
      this.startRecording = this.startRecording.bind(this);
      this.stopRecording = this.stopRecording.bind(this);
      this.state = {
        startbtnDisabled: false,
        stopbtnDisabled: true,
        recognizer: this.RecognizerSetup(SDK,"Interactive","en-US", "Simple" , "A40d6ac6354d414a9dc9739280ff526f"),
        dothrakiWord: "",
        englishWord: ""
      };
    }

   public render() {
      return (
        <div className="row">
            <div className="col"> 
                <Label>Dothraki translator</Label>
            </div>
            <div className="col"> 
                <IconButton
                    disabled={ this.state.startbtnDisabled }
                    checked={ this.state.stopbtnDisabled }
                    iconProps={ { iconName: 'Record2' } }
                    title='Record'
                    ariaLabel='Record'
                    onClick={this.startRecording}
                />
                <div className="col">
                    <div className="row"> 
                        <div className="col">
                            <Label>English phrase spoken: {this.state.englishWord}</Label>
                        </div>
                        <div className="col">
                            <Label>Dothraki translation: {this.state.dothrakiWord}</Label>
                        </div>
                    </div>
                </div>
            </div>
         
        </div>
      );
    }

    public  componentDidMount() {
      this.Setup();
      var utterThis = new SpeechSynthesisUtterance("Welcome to the Dothraki translator, press the record button to start");
      utterThis.voice = speechSynthesis.getVoices().filter(function (voice) { return voice.name === "Google русский"; })[0];
      var synth = window.speechSynthesis;
      synth.speak(utterThis);
    }

    public startRecording(){
      this.RecognizerStart(SDK, this.state.recognizer);
    }

    public stopRecording() {
      this.RecognizerStop(SDK, this.state.recognizer);
    }

    public RecognizerStop(SDK, recognizer) {
      // recognizer.AudioSource.Detach(audioNodeId) can be also used here. (audioNodeId is part of ListeningStartedEvent)
      recognizer.AudioSource.TurnOff();
    }
      
    public RecognizerSetup(SDK, recognitionMode, language, format, subscriptionKey) {
      
      switch (recognitionMode) {
          case "Interactive" :
              recognitionMode = SDK.RecognitionMode.Interactive;    
              break;
          case "Conversation" :
              recognitionMode = SDK.RecognitionMode.Conversation;    
              break;
          case "Dictation" :
              recognitionMode = SDK.RecognitionMode.Dictation;    
              break;
          default:
              recognitionMode = SDK.RecognitionMode.Interactive;
      }

      var recognizerConfig = new SDK.RecognizerConfig(
          new SDK.SpeechConfig(
              new SDK.Context(
                  new SDK.OS(navigator.userAgent, "Browser", null),
                  new SDK.Device("SpeechSample", "SpeechSample", "1.0.00000"))),
          recognitionMode,
          language, // Supported languages are specific to each recognition mode. Refer to docs.
          format); // SDK.SpeechResultFormat.Simple (Options - Simple/Detailed)


      var useTokenAuth = false;
      
      var authentication = function() {
          if (!useTokenAuth)
              return new SDK.CognitiveSubscriptionKeyAuthentication(subscriptionKey);

          var callback = function() {
              var tokenDeferral = new SDK.Deferred();
              try {
                  var xhr = new(XMLHttpRequest);
                  xhr.open('GET', '/token', true);
                  xhr.onload = function () {
                      if (xhr.status === 200)  {
                          tokenDeferral.Resolve(xhr.responseText);
                      } else {
                          tokenDeferral.Reject('Issue token request failed.');
                      }
                  };
                  xhr.send();
              } catch (e) {
                  window.console && console.log(e);
                  tokenDeferral.Reject(e.message);
              }
              return tokenDeferral.Promise();
          };

          return new SDK.CognitiveTokenAuthentication(callback, callback);
      }();
          return SDK.CreateRecognizer(recognizerConfig, authentication);
  }
      
  public RecognizerStart(SDK, recognizer) {
    recognizer.Recognize((event) => {
        /*
         Alternative syntax for typescript devs.
         if (event instanceof SDK.RecognitionTriggeredEvent)
        */
        switch (event.Name) {
            case "RecognitionTriggeredEvent" :
                this.UpdateStatus("Initializing");
                break;
            case "ListeningStartedEvent" :
                this.UpdateStatus("Listening");
                break;
            case "RecognitionStartedEvent" :
                this.UpdateStatus("Listening_Recognizing");
                break;
            case "SpeechStartDetectedEvent" :
                this.UpdateStatus("Listening_DetectedSpeech_Recognizing");
                console.log(JSON.stringify(event.Result)); // check console for other information in result
                break;
            case "SpeechHypothesisEvent" :
                this.UpdateRecognizedHypothesis(event.Result.Text, false);
                console.log(JSON.stringify(event.Result)); // check console for other information in result
                break;
            case "SpeechFragmentEvent" :
                this.UpdateRecognizedHypothesis(event.Result.Text, true);
                console.log(JSON.stringify(event.Result)); // check console for other information in result
                break;
            case "SpeechEndDetectedEvent" :
                this.OnSpeechEndDetected();
                this.UpdateStatus("Processing_Adding_Final_Touches");
                console.log(JSON.stringify(event.Result)); // check console for other information in result
                break;
            case "SpeechSimplePhraseEvent" :
                this.UpdateRecognizedPhrase(JSON.stringify(event.Result, null, 3));
                break;
            case "SpeechDetailedPhraseEvent" :
                this.UpdateRecognizedPhrase(JSON.stringify(event.Result, null, 3));
                break;
            case "RecognitionEndedEvent" :
                this.OnComplete();
                this.UpdateStatus("Idle");
                console.log(JSON.stringify(event)); // Debug information
                break;
            default:
                console.log(JSON.stringify(event)); // Debug information
        }
    })
    .On(() => {
        // The request succeeded. Nothing to do here.
    },
    (error) => {
        console.error(error);
    });
}

    public OnComplete() {
      this.setState({startbtnDisabled: false, stopbtnDisabled: true});
    }
    public OnSpeechEndDetected() {
      this.setState({startbtnDisabled: false, stopbtnDisabled: true});
    }

    public Setup() {
      if (this.state.recognizer != null) {
          this.RecognizerStop(SDK, this.state.recognizer);
      }
      this.state = {
        startbtnDisabled: false,
        stopbtnDisabled: true,
        recognizer: this.RecognizerSetup(SDK,"Interactive","en-US", "Simple" , "A40d6ac6354d414a9dc9739280ff526f"),
        dothrakiWord: "",
        englishWord: ""
      };
    }

    public UpdateStatus(status) {
      console.log(status);
    }

    public UpdateRecognizedHypothesis(text, append) {
      console.log("UPDATE RECOGNIZEdHypo", text);
      this.setState({englishWord: text});
    }

    public UpdateRecognizedPhrase(json) {
      console.log("UPDATE RECONGIZEDPHRASE", json);
      var translationPhraseGroup = JSON.parse(json);
      var strippedTranslationPhrase = translationPhraseGroup.DisplayText.replace(/[^a-zA-Z ]/g, "");
      this.GetDothrakiWord(strippedTranslationPhrase);
    }

    public GetDothrakiWord(PhraseJson){
      var restUrl = "https://dothrakitranslatorservice.azurewebsites.net/api/HttpTriggerCSharp/phrase/"+ PhraseJson +"?code=mZwT4P00yS2J0wSCqivZzh0t7aZYInBRi63O0CBgYn/2i/H6hZNJkQ==";
      console.log(restUrl);
      fetch(restUrl)
      .then((response) => response.json())
      .catch((error) => console.warn("fetch error:", error))
      .then((json) => {
        var dothrakiWordJson:any = json;
        this.setState({dothrakiWord: dothrakiWordJson.Dothraki});

        var utterThis = new SpeechSynthesisUtterance(dothrakiWordJson.Dothraki);
        
        console.log(speechSynthesis);
        utterThis.voice = speechSynthesis.getVoices().filter(function (voice) { return voice.name === "Google русский"; })[0];
        var synth = window.speechSynthesis;
        synth.speak(utterThis);
      });
    }
  }