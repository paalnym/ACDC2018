import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Version } from '@microsoft/sp-core-library';
import {
  BaseClientSideWebPart,
  IPropertyPaneConfiguration,
  PropertyPaneTextField
} from '@microsoft/sp-webpart-base';

import * as strings from 'DothrakiTranslatorWebPartWebPartStrings';
import DothrakiTranslatorWebPart from './components/DothrakiTranslatorWebPart';
import { IDothrakiTranslatorWebPartProps } from './components/IDothrakiTranslatorWebPartProps';

export interface IDothrakiTranslatorWebPartWebPartProps {
  description: string;
}

export default class DothrakiTranslatorWebPartWebPart extends BaseClientSideWebPart<IDothrakiTranslatorWebPartWebPartProps> {

  public render(): void {
    const element: React.ReactElement<IDothrakiTranslatorWebPartProps > = React.createElement(
      DothrakiTranslatorWebPart,
      {
        description: this.properties.description
      }
    );

    ReactDom.render(element, this.domElement);
  }

  protected get dataVersion(): Version {
    return Version.parse('1.0');
  }

  protected getPropertyPaneConfiguration(): IPropertyPaneConfiguration {
    return {
      pages: [
        {
          header: {
            description: strings.PropertyPaneDescription
          },
          groups: [
            {
              groupName: strings.BasicGroupName,
              groupFields: [
                PropertyPaneTextField('description', {
                  label: strings.DescriptionFieldLabel
                })
              ]
            }
          ]
        }
      ]
    };
  }
}
