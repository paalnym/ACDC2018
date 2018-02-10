export interface IDothrakiMicProps {
    recognitionMode: string, 
    language: string, 
    format: string, 
    subscriptionKey: string
}

declare module 'microsoft-speech-browser-sdk' {
    export var index: any;
}

