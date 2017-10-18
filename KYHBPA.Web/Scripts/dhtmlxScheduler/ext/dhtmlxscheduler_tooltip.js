/*
@license
dhtmlxScheduler.Net v.3.4.0 Professional Evaluation

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){!function(){var t=e.dhtmlXTooltip=e.tooltip={};t.config={className:"dhtmlXTooltip tooltip",timeout_to_display:50,timeout_to_hide:50,delta_x:15,delta_y:-20},t.tooltip=document.createElement("div"),t.tooltip.className=t.config.className,e._waiAria.tooltipAttr(t.tooltip),t.show=function(a,n){if(!e.config.touch||e.config.touch_tooltip){var i=t,r=this.tooltip,o=r.style;i.tooltip.className=i.config.className;var s=this.position(a),d=a.target||a.srcElement;if(!this.isTooltip(d)){
var _=s.x+(i.config.delta_x||0),l=s.y-(i.config.delta_y||0);o.visibility="hidden",o.removeAttribute?(o.removeAttribute("right"),o.removeAttribute("bottom")):(o.removeProperty("right"),o.removeProperty("bottom")),o.left="0",o.top="0",this.tooltip.innerHTML=n,document.body.appendChild(this.tooltip);var c=this.tooltip.offsetWidth,h=this.tooltip.offsetHeight;document.documentElement.clientWidth-_-c<0?(o.removeAttribute?o.removeAttribute("left"):o.removeProperty("left"),o.right=document.documentElement.clientWidth-_+2*(i.config.delta_x||0)+"px"):0>_?o.left=s.x+Math.abs(i.config.delta_x||0)+"px":o.left=_+"px",
document.documentElement.clientHeight-l-h<0?(o.removeAttribute?o.removeAttribute("top"):o.removeProperty("top"),o.bottom=document.documentElement.clientHeight-l-2*(i.config.delta_y||0)+"px"):0>l?o.top=s.y+Math.abs(i.config.delta_y||0)+"px":o.top=l+"px",e._waiAria.tooltipVisibleAttr(this.tooltip),o.visibility="visible",this.tooltip.onmouseleave=function(t){t=t||window.event;for(var a=e.dhtmlXTooltip,n=t.relatedTarget;n!=e._obj&&n;)n=n.parentNode;n!=e._obj&&a.delay(a.hide,a,[],a.config.timeout_to_hide);
},e.callEvent("onTooltipDisplayed",[this.tooltip,this.tooltip.event_id])}}},t._clearTimeout=function(){this.tooltip._timeout_id&&window.clearTimeout(this.tooltip._timeout_id)},t.hide=function(){if(this.tooltip.parentNode){e._waiAria.tooltipHiddenAttr(this.tooltip);var t=this.tooltip.event_id;this.tooltip.event_id=null,this.tooltip.onmouseleave=null,this.tooltip.parentNode.removeChild(this.tooltip),e.callEvent("onAfterTooltip",[t])}this._clearTimeout()},t.delay=function(e,t,a,n){this._clearTimeout(),
this.tooltip._timeout_id=setTimeout(function(){var n=e.apply(t,a);return e=t=a=null,n},n||this.config.timeout_to_display)},t.isTooltip=function(e){for(var t=!1;e&&!t;)t=e.className==this.tooltip.className,e=e.parentNode;return t},t.position=function(e){return e=e||window.event,{x:e.clientX,y:e.clientY}},e.attachEvent("onMouseMove",function(a,n){var i=window.event||n,r=i.target||i.srcElement,o=t,s=o.isTooltip(r),d=o.isTooltipTarget&&o.isTooltipTarget(r);if(a||s||d){var _;if(a||o.tooltip.event_id){
var l=e.getEvent(a)||e.getEvent(o.tooltip.event_id);if(!l)return;if(o.tooltip.event_id=l.id,_=e.templates.tooltip_text(l.start_date,l.end_date,l),!_)return o.hide()}d&&(_="");var c;if(_isIE){c={pageX:void 0,pageY:void 0,clientX:void 0,clientY:void 0,target:void 0,srcElement:void 0};for(var h in c)c[h]=i[h]}if(!e.callEvent("onBeforeTooltip",[a])||!_)return;o.delay(o.show,o,[c||i,_])}else o.delay(o.hide,o,[],o.config.timeout_to_hide)}),e.attachEvent("onBeforeDrag",function(){return t.hide(),!0}),e.attachEvent("onEventDeleted",function(){
return t.hide(),!0})}()});