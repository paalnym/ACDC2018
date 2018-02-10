import * as React from 'react';
import styles from './DothrakiTranslatorWebPart.module.scss';
import { IDothrakiTranslatorWebPartProps } from './IDothrakiTranslatorWebPartProps';
import { escape } from '@microsoft/sp-lodash-subset';
import DothrakiMic from './DothrakiMic/DothrakiMic';

export default class DothrakiTranslatorWebPart extends React.Component<IDothrakiTranslatorWebPartProps, {}> {
  public render(): React.ReactElement<IDothrakiTranslatorWebPartProps> {
    return (
      <div className={ styles.dothrakiTranslatorWebPart }>
        <div className={ styles.dothrakiTranslatorWebPartContainer}><DothrakiMic recognitionMode={""} language={""} format={""} subscriptionKey={""} /></div>
      </div>
    );
  }
}
