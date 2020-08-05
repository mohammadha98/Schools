/*
* jQuery-Simple-Timer
*
* Creates a countdown timer.
*
* Example:
*   $('.timer').startTimer();
*
*/
(function($){

  var timer;

  var Timer = function(targetElement){
    this.targetElement = targetElement;
    return this;
  };

  Timer.start = function(options, targetElement){
    timer = new Timer(targetElement);
    return timer.start(options);
  };

  Timer.prototype.start = function(options) {

    var createSubDivs = function(timerBoxElement){
      var seconds = document.createElement('span');
      seconds.className = 'seconds';

      var minutes = document.createElement('span');
      minutes.className = 'minutes';

      var hours = document.createElement('span');
      hours.className = 'hours';

      var days = document.createElement('span');
      days.className = 'days';

      var clearDiv = document.createElement('div');
      clearDiv.className = 'clearfix';

      return timerBoxElement.
        append(days).
        append(hours).
        append(minutes).
        append(seconds).
        append(clearDiv);
    };

    this.targetElement.each(function(_index, timerBox) {
      var timerBoxElement = $(timerBox);
      var cssClassSnapshot = timerBoxElement.attr('class');

      timerBoxElement.on('complete', function() {
        clearInterval(timerBoxElement.intervalId);
      });

      timerBoxElement.on('complete', function() {
        timerBoxElement.onComplete(timerBoxElement);
      });

      timerBoxElement.on('complete', function(){
        timerBoxElement.addClass('timeout');
      });

      timerBoxElement.on('complete', function(){
        if(options && options.loop === true) {
          timer.resetTimer(timerBoxElement, options, cssClassSnapshot);
        }
      });

      createSubDivs(timerBoxElement);
      return this.startCountdown(timerBoxElement, options);
    }.bind(this));
  };

  /**
   * Resets timer and add css class 'loop' to indicate the timer is in a loop.
   * $timerBox {jQuery object} - The timer element
   * options {object} - The options for the timer
   * css - The original css of the element
   */
  Timer.prototype.resetTimer = function($timerBox, options, css) {
    var interval = 0;
    if(options.loopInterval) {
      interval = parseInt(options.loopInterval, 10) * 1000;
    }
    setTimeout(function() {
      $timerBox.trigger('reset');
      $timerBox.attr('class', css + ' loop');
      timer.startCountdown($timerBox, options);
    }, interval);
  }

  Timer.prototype.fetchSecondsLeft = function(element){
    var secondsLeft = element.data('seconds-left');
    var minutesLeft = element.data('minutes-left');

    if(secondsLeft){
      console.log('seconds: ' + secondsLeft);
      console.log('seconds: ' + parseInt(secondsLeft, 10));
      return parseInt(secondsLeft, 10);
    } else if(minutesLeft) {
      return parseFloat(minutesLeft) * 60;
    }else {
      throw 'Missing time data';
    }
  };

  Timer.prototype.startCountdown = function(element, options) {
    options = options || {};

    var intervalId = null;
    var defaultComplete = function(){
      clearInterval(intervalId);
      return this.clearTimer(element);
    }.bind(this);

    element.onComplete = options.onComplete || defaultComplete;

    var secondsLeft = this.fetchSecondsLeft(element);

    var refreshRate = options.refreshRate || 1000;
    var endTime = secondsLeft + this.currentTime();
    var timeLeft = endTime - this.currentTime();

    this.setFinalValue(this.formatTimeLeft(timeLeft), element);

    intervalId = setInterval((function() {
      timeLeft = endTime - this.currentTime();
      this.setFinalValue(this.formatTimeLeft(timeLeft), element);
    }.bind(this)), refreshRate);

    element.intervalId = intervalId;
  };

  Timer.prototype.clearTimer = function(element){
    element.find('.seconds').text('00');
    element.find('.minutes').text('00');
    element.find('.hours').text('00');
    element.find('.days').text('00');
  };

  Timer.prototype.currentTime = function() {
    return Math.round((new Date()).getTime() / 1000);
  };

  Timer.prototype.formatTimeLeft = function(timeLeft) {

    var lpad = function(n, width) {
      width = width || 2;
      n = n + '';

      var padded = null;

      if (n.length >= width) {
        padded = n;
      } else {
        padded = Array(width - n.length + 1).join(0) + n;
      }

      return padded;
    };

    var days, hours, minutes, remaining, seconds, secs;
    secs = timeLeft;
    remaining = new Date(timeLeft * 1000);

    // hours = remaining.getUTCHours();
    // minutes = remaining.getUTCMinutes();
    // seconds = remaining.getUTCSeconds();

  days = ( secs / 86400 ) >> 0;
  hours = ( secs % 86400 / 3600 ) >> 0;
  minutes = ( secs % 3600 / 60 ) >> 0;
  seconds = ( secs % 60 );    
/* seconds = seconds < 10 ? "0" + seconds : seconds;
  minutes = minutes < 10 ? "0" + minutes : minutes;
  hours = hours && hours < 10 ? "0" + hours : hours;*/

  /*if(days > 0){
    console.log(days * 24);
    hours = parseInt(hours, 10) + (days * 24);
    console.log(hours);
  }*/


    if (+hours === 0 && +minutes === 0 && +seconds === 0) {
      return [];
    } else {
      return [lpad(days),lpad(hours), lpad(minutes), lpad(seconds)];
    }
  };

  Timer.prototype.setFinalValue = function(finalValues, element) {

    if(finalValues.length === 0){
      this.clearTimer(element);
      element.trigger('complete');
      return false;
    }

    element.find('.seconds').text(finalValues.pop());
    element.find('.minutes').text(finalValues.pop());
    element.find('.hours').text(finalValues.pop());
    element.find('.days').text(finalValues.pop());
  };


  $.fn.startTimer = function(options) {
    Timer.start(options, this);
    return this;
  };
})(jQuery);
