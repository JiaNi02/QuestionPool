(window.webpackJsonp=window.webpackJsonp||[]).push([[13],{1368:function(o,t,e){var n=e(30),a=e(1430);"string"==typeof(a=a.__esModule?a.default:a)&&(a=[[o.i,a,""]]);var r={insert:function(o){if(!window.isApryseWebViewerWebComponent)return void document.head.appendChild(o);let t;t=document.getElementsByTagName("apryse-webviewer"),t.length||(t=function o(t,e=document){const n=[];return e.querySelectorAll(t).forEach(o=>n.push(o)),e.querySelectorAll("*").forEach(e=>{e.shadowRoot&&n.push(...o(t,e.shadowRoot))}),n}("apryse-webviewer"));const e=[];for(let n=0;n<t.length;n++){const a=t[n];if(0===n)a.shadowRoot.appendChild(o),o.onload=function(){e.length>0&&e.forEach(t=>{t.innerHTML=o.innerHTML})};else{const t=o.cloneNode(!0);a.shadowRoot.appendChild(t),e.push(t)}}},singleton:!1};n(a,r);o.exports=a.locals||{}},1372:function(o,t,e){"use strict";e(19),e(12),e(14),e(7),e(13),e(9),e(10),e(11),e(16),e(15),e(20),e(18);var n=e(0),a=e.n(n),r=e(391),i=e(115),l=e(4),u=e.n(l),c=e(71),d=e(139),s=e(257),p=(e(1424),e(47)),b=e(21);function k(o,t){return function(o){if(Array.isArray(o))return o}(o)||function(o,t){var e=null==o?null:"undefined"!=typeof Symbol&&o[Symbol.iterator]||o["@@iterator"];if(null!=e){var n,a,r,i,l=[],u=!0,c=!1;try{if(r=(e=e.call(o)).next,0===t){if(Object(e)!==e)return;u=!1}else for(;!(u=(n=r.call(e)).done)&&(l.push(n.value),l.length!==t);u=!0);}catch(o){c=!0,a=o}finally{try{if(!u&&null!=e.return&&(i=e.return(),Object(i)!==i))return}finally{if(c)throw a}}return l}}(o,t)||function(o,t){if(!o)return;if("string"==typeof o)return m(o,t);var e=Object.prototype.toString.call(o).slice(8,-1);"Object"===e&&o.constructor&&(e=o.constructor.name);if("Map"===e||"Set"===e)return Array.from(o);if("Arguments"===e||/^(?:Ui|I)nt(?:8|16|32)(?:Clamped)?Array$/.test(e))return m(o,t)}(o,t)||function(){throw new TypeError("Invalid attempt to destructure non-iterable instance.\nIn order to be iterable, non-array objects must have a [Symbol.iterator]() method.")}()}function m(o,t){(null==t||t>o.length)&&(t=o.length);for(var e=0,n=new Array(t);e<t;e++)n[e]=o[e];return n}var g={type:u.a.oneOf(["bookmark","outline","portfolio"]).isRequired,anchorButton:u.a.string.isRequired,shouldDisplayDeleteButton:u.a.bool,onClosePopup:u.a.func.isRequired,onRenameClick:u.a.func,onSetDestinationClick:u.a.func,onDownloadClick:u.a.func,onDeleteClick:u.a.func,onOpenClick:u.a.func},f=function(o){var t=o.type,e=o.anchorButton,l=o.shouldDisplayDeleteButton,u=o.onClosePopup,m=o.onRenameClick,g=o.onSetDestinationClick,f=o.onDownloadClick,h=o.onDeleteClick,v=o.onOpenClick,w=k(Object(r.a)(),1)[0],x=Object(n.useRef)(null),y=k(Object(n.useState)({left:-100,right:"auto",top:"auto"}),2),C=y[0],E=y[1],j=function(o){var t=o.children,e=o.position,n=Object(b.a)().querySelector("#outline-edit-popup-portal");return n.style.position="absolute",n.style.top="auto"===e.top?e.top:"".concat(e.top,"px"),n.style.left="auto"===e.left?e.left:"".concat(e.left,"px"),n.style.right="auto"===e.right?e.right:"".concat(e.right,"px"),n.style.zIndex=999,Object(i.createPortal)(t,n)};Object(n.useEffect)((function(){var o=Object(s.a)(e,x);E(o)}),[e]);var O=Object(n.useCallback)((function(o){null!=x&&x.current.contains(o.target)||u()}));return Object(d.a)(x,O),a.a.createElement(j,{position:C},a.a.createElement(c.a,{ref:x,className:"more-options-context-menu-popup",dataElement:"".concat(t,"EditPopup")},"portfolio"===t&&v&&a.a.createElement(p.a,{className:"option-button",dataElement:"".concat(t,"OpenFileButton"),img:"icon-portfolio-file",label:w("portfolio.openFile"),ariaLabel:w("portfolio.openFile"),onClick:function(o){o.stopPropagation(),v()}}),a.a.createElement(p.a,{className:"option-button",dataElement:"".concat(t,"RenameButton"),img:"ic_edit_page_24px",label:w("action.rename"),ariaLabel:w("action.rename"),onClick:function(o){o.stopPropagation(),m()}}),"outline"===t&&a.a.createElement(p.a,{className:"option-button",dataElement:"".concat(t,"SetDestinationButton"),img:"icon-thumbtack",label:w("action.setDestination"),ariaLabel:w("action.setDestination"),onClick:function(o){o.stopPropagation(),g()}}),"portfolio"===t&&a.a.createElement(p.a,{className:"option-button",dataElement:"".concat(t,"DownloadButton"),img:"icon-download",label:w("action.download"),ariaLabel:w("action.download"),onClick:function(o){o.stopPropagation(),f()}}),l&&a.a.createElement(p.a,{className:"option-button",dataElement:"".concat(t,"DeleteButton"),img:"icon-delete-line",label:w("action.delete"),ariaLabel:w("action.delete"),onClick:function(o){o.stopPropagation(),h()}})))};f.propTypes=g;var h=f;t.a=h},1424:function(o,t,e){var n=e(30),a=e(1425);"string"==typeof(a=a.__esModule?a.default:a)&&(a=[[o.i,a,""]]);var r={insert:function(o){if(!window.isApryseWebViewerWebComponent)return void document.head.appendChild(o);let t;t=document.getElementsByTagName("apryse-webviewer"),t.length||(t=function o(t,e=document){const n=[];return e.querySelectorAll(t).forEach(o=>n.push(o)),e.querySelectorAll("*").forEach(e=>{e.shadowRoot&&n.push(...o(t,e.shadowRoot))}),n}("apryse-webviewer"));const e=[];for(let n=0;n<t.length;n++){const a=t[n];if(0===n)a.shadowRoot.appendChild(o),o.onload=function(){e.length>0&&e.forEach(t=>{t.innerHTML=o.innerHTML})};else{const t=o.cloneNode(!0);a.shadowRoot.appendChild(t),e.push(t)}}},singleton:!1};n(a,r);o.exports=a.locals||{}},1425:function(o,t,e){(o.exports=e(31)(!1)).push([o.i,".more-options-context-menu-popup{padding-top:var(--padding-small);padding-bottom:var(--padding-small);background-color:var(--component-background);box-shadow:0 0 3px var(--document-box-shadow);border-radius:4px}.more-options-context-menu-popup .option-button{justify-content:flex-start;width:100%;padding:var(--padding-small) var(--padding-medium);border-radius:0}.more-options-context-menu-popup .option-button:not(:first-child){margin-top:var(--padding-small)}.more-options-context-menu-popup .option-button:hover{background-color:var(--tools-header-background)}.more-options-context-menu-popup .option-button .Icon{width:20px;height:auto;margin-right:10px}",""])},1430:function(o,t,e){(o.exports=e(31)(!1)).push([o.i,".bookmark-outline-panel{display:flex;padding-left:var(--padding);padding-right:var(--padding-small)}.bookmark-outline-control-button{width:auto}.bookmark-outline-control-button span{color:inherit}.bookmark-outline-control-button,.bookmark-outline-control-button.disabled,.bookmark-outline-control-button[disabled]{color:var(--secondary-button-text)}.bookmark-outline-control-button.disabled,.bookmark-outline-control-button[disabled]{opacity:.5}.bookmark-outline-control-button.disabled span,.bookmark-outline-control-button[disabled] span{color:inherit}.bookmark-outline-control-button:not(.disabled):active,.bookmark-outline-control-button:not(.disabled):focus,.bookmark-outline-control-button:not(.disabled):hover,.bookmark-outline-control-button:not([disabled]):active,.bookmark-outline-control-button:not([disabled]):focus,.bookmark-outline-control-button:not([disabled]):hover{color:var(--secondary-button-hover)}.bookmark-outline-panel-header{display:flex;flex-flow:row nowrap;justify-content:space-between;align-items:center;padding-bottom:var(--padding-tiny);border-bottom:1px solid var(--border)}.bookmark-outline-panel-header .header-title{font-size:16px}.bookmark-outline-row{flex-grow:1;overflow-y:auto}.msg-no-bookmark-outline{color:var(--placeholder-text);text-align:center}.bookmark-outline-single-container{display:flex;flex-flow:row nowrap;align-items:flex-start;border-radius:4px}.bookmark-outline-single-container.default{padding:var(--padding-small) var(--padding-tiny);border:1px solid transparent}.bookmark-outline-single-container.default.hover,.bookmark-outline-single-container.default:hover{cursor:pointer}.bookmark-outline-single-container.default.hover .bookmark-outline-more-button,.bookmark-outline-single-container.default:hover .bookmark-outline-more-button{display:flex}.bookmark-outline-single-container.default:hover{background-color:var(--outline-selected)}.bookmark-outline-single-container.default.hover,.bookmark-outline-single-container.default.selected{background-color:var(--popup-button-active)}.bookmark-outline-single-container.default .bookmark-outline-label-row{overflow:hidden}.bookmark-outline-single-container.editing{background-color:var(--faded-component-background);padding:var(--padding-medium) 20px}.bookmark-outline-single-container.preview{display:inline-flex;margin-top:0;padding:var(--padding-small);background-color:var(--component-background);box-shadow:0 0 3px var(--note-box-shadow)}.bookmark-outline-single-container .bookmark-outline-checkbox{flex-grow:0;flex-shrink:0;margin-top:1px;margin-bottom:0;margin-right:var(--padding-small)}.bookmark-outline-single-container .bookmark-outline-label-row{flex-grow:1;flex-shrink:1;display:flex;flex-flow:row wrap;align-items:flex-start;position:relative;overflow:hidden}.bookmark-outline-single-container .bookmark-outline-label{font-weight:600;flex-grow:1;flex-shrink:1;margin-bottom:var(--padding-small)}.bookmark-outline-single-container .bookmark-outline-input,.bookmark-outline-single-container .bookmark-outline-text{flex-grow:1;flex-shrink:1;flex-basis:calc(100% - 18px)}.bookmark-outline-single-container .bookmark-text-input{margin-left:var(--padding-large)}.bookmark-outline-single-container .bookmark-outline-input{color:var(--text-color);width:calc(100% - var(--padding-large));padding:var(--padding-small);border:1px solid var(--border)}.bookmark-outline-single-container .bookmark-outline-input:focus{border-color:var(--outline-color)}.bookmark-outline-single-container .bookmark-outline-input::-moz-placeholder{color:var(--placeholder-text)}.bookmark-outline-single-container .bookmark-outline-input:-ms-input-placeholder{color:var(--placeholder-text)}.bookmark-outline-single-container .bookmark-outline-input::placeholder{color:var(--placeholder-text)}.bookmark-outline-single-container .bookmark-outline-more-button{display:none;flex-grow:0;flex-shrink:0;width:auto;height:auto;margin-left:var(--padding-tiny);margin-right:0}.bookmark-outline-single-container .bookmark-outline-more-button .Icon{width:14px;height:14px}.bookmark-outline-single-container .bookmark-outline-editing-controls{flex-basis:100%;display:flex;flex-flow:row wrap;justify-content:flex-end;align-items:center;margin-top:var(--padding-medium)}.bookmark-outline-single-container .bookmark-outline-cancel-button,.bookmark-outline-single-container .bookmark-outline-save-button{width:auto;padding:6px var(--padding)}.bookmark-outline-single-container .bookmark-outline-cancel-button{color:var(--secondary-button-text)}.bookmark-outline-single-container .bookmark-outline-cancel-button:hover{color:var(--secondary-button-hover)}.bookmark-outline-single-container .bookmark-outline-save-button{color:var(--primary-button-text);background-color:var(--primary-button);margin-left:var(--padding-tiny);border-radius:4px}.bookmark-outline-single-container .bookmark-outline-save-button:hover{background-color:var(--primary-button-hover)}.bookmark-outline-single-container .bookmark-outline-save-button.disabled,.bookmark-outline-single-container .bookmark-outline-save-button:disabled{background-color:var(--primary-button)!important;opacity:.5}.bookmark-outline-footer{border-top:1.5px solid var(--border);padding-top:var(--padding-medium);padding-bottom:var(--padding-medium);display:flex;justify-content:center;align-items:center}.bookmark-outline-footer .add-new-button .Icon{width:14px;height:14px;margin-right:var(--padding-tiny);color:inherit;fill:currentColor}.bookmark-outline-footer .add-new-button.disabled .Icon.disabled,.bookmark-outline-footer .add-new-button.disabled .Icon.disabled path,.bookmark-outline-footer .add-new-button[disabled] .Icon.disabled,.bookmark-outline-footer .add-new-button[disabled] .Icon.disabled path{color:inherit;fill:currentColor}.bookmark-outline-footer .multi-selection-button{width:auto;padding:7px}.bookmark-outline-footer .multi-selection-button .Icon{width:18px;height:18px}.bookmark-outline-footer .multi-selection-button:not(:first-child){margin-left:var(--padding-tiny)}.bookmark-outline-footer .multi-selection-button:hover{background-color:var(--view-header-button-hover)}",""])}}]);
//# sourceMappingURL=13.chunk.js.map