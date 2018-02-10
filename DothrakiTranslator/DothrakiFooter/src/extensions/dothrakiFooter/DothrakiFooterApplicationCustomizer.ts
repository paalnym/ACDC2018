import { override } from '@microsoft/decorators';
import { Log } from '@microsoft/sp-core-library';
import {
  BaseApplicationCustomizer, PlaceholderContent, PlaceholderName, PlaceholderProvider
} from '@microsoft/sp-application-base';
import { escape } from '@microsoft/sp-lodash-subset';

const LOG_SOURCE: string = 'COBApplicationCustomizer';
const HEADER_TEXT: string = "This is the top zone";
const FOOTER_TEXT: string = "This is the bottom zone";

// used if you wish to pass properties to your extension..
export interface IDothrakiFooterApplicationCustomizerProperties {
  TopContent: string;
}

export default class DothrakiFooterApplicationCustomizer
  extends BaseApplicationCustomizer<IDothrakiFooterApplicationCustomizerProperties> {

  @override
  public onInit(): Promise<void> {
    console.log("onInit: Entered");

    console.log("Available placeholders: ",
      this.context.placeholderProvider.placeholderNames.join(", "));

    // top placeholder..
    let topPlaceholder: PlaceholderContent = this.context.placeholderProvider.tryCreateContent(PlaceholderName.Top);
    if (topPlaceholder) {
      topPlaceholder.domElement.innerHTML = `<div class="">
                  <div class="ms-bgColor-themeDark ms-fontColor-white">
                    <i class="ms-Icon ms-Icon--Info" aria-hidden="true"></i>&nbsp; ${escape(HEADER_TEXT)}
                  </div>
                </div>`;
    }

    // bottom placeholder..
    let bottomPlaceholder: PlaceholderContent = this.context.placeholderProvider.tryCreateContent(PlaceholderName.Bottom);
    if (bottomPlaceholder) {
      bottomPlaceholder.domElement.innerHTML = `<div class="">
                  <div class="ms-bgColor-themeDark ms-fontColor-white">
                    <i class="ms-Icon ms-Icon--Info" aria-hidden="true"></i>&nbsp; ${escape(FOOTER_TEXT)}
                  </div>
                </div>`;
    }

    return Promise.resolve<void>();
  }
}