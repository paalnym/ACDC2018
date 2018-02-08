import * as React from "react";
import { IDothrakiMicProps } from "./IDothrakiMicProps";
import { IDothrakiMicState } from "./IDothrakiMicState";
import { DefaultButton, Label } from 'office-ui-fabric-react/lib';
import * as SDK from 'microsoft-speech-browser-sdk';

export default class DothrakiMic extends React.Component<IDothrakiMicProps, IDothrakiMicState> {
  constructor(props) {
      super(props);
      this.startRecording = this.startRecording.bind(this);
      this.stopRecording = this.stopRecording.bind(this);
      this.state = {
        startbtnDisabled: false,
        stopbtnDisabled: true,
        recognizer: this.RecognizerSetup(SDK,"Interactive","en-US", "Simple" , "A40d6ac6354d414a9dc9739280ff526f")
      }
    }

    render() {
      return (
        <div className='ms-BasicButtonsTwoUp'>
          <div>
            <Label>Standard</Label>
            <DefaultButton
              primary={ true }
              disabled={ this.state.startbtnDisabled }
              text='Start recording'
              onClick={ this.startRecording }
            />
          </div>
          <div>
            <Label>Primary</Label>
            <DefaultButton
              primary={ true }
              disabled={ this.state.stopbtnDisabled }
              text='Stop recording'
              onClick={ this.stopRecording }
            />
          </div>
        </div>
      );
    }

    componentDidMount() {
      this.Setup();
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
          }

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
      this.state = {
        startbtnDisabled: false,
        stopbtnDisabled: true,
        recognizer: this.state.recognizer
      }
    }
    public OnSpeechEndDetected() {
      this.state = {
        startbtnDisabled: false,
        stopbtnDisabled: true,
        recognizer: this.state.recognizer
      }
    }

    public Setup() {
      if (this.state.recognizer != null) {
          this.RecognizerStop(SDK, this.state.recognizer);
      }
      this.state = {
        startbtnDisabled: false,
        stopbtnDisabled: true,
        recognizer: this.RecognizerSetup(SDK,"Interactive","en-US", "Simple" , "A40d6ac6354d414a9dc9739280ff526f")
      }
    }

    public UpdateStatus(status) {
      console.log(status);
    }

    public UpdateRecognizedHypothesis(text, append) {
      if (append) 
      console.log(text);
    }

    public UpdateRecognizedPhrase(json) {
      console.log(json);
    }
  }
