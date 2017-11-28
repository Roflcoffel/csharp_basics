//Exercise 1
window.setInterval(function () {
    var d = new Date();
    document.getElementById("clock").innerHTML = d.toUTCString();
}, 1000)


//Exercise 2
function checkLeapYear() {
    var year = documet.getElementById("leapYear").value;

    var isLeapYear = new Date(year, 1, 29).getMonth() == 1;

    alert(isLeapYear);

    if (isLeapYear) {
        document.getElementById("leapYearText").innerHTML = "is a leap year";
    }
    else {
        document.getElementById("leapYearText").innerHTML = "is NOT a leap year";
    }
}


//Exercise 3
function checkJanuary() {
    var year = document.getElementById("year").value;

    var isFirstSunday = new Date(year, 0, 1).getDay() == 0

    if (isFirstSunday) {
        document.getElementById("janSunText").innerHTML = "is a sunday"
    }
    else {
        document.getElementById("janSunText").innerHTML = "is NOT a sunday"
    }
}

//Exercise 4 (Params from HTML)
function guess(num) {
    var rnd = Math.floor(Math.random() * 10) + 1;

    if (rnd == num) {
        document.getElementById("guessText").innerHTML = "That is Correct!"
    }
    else {
        document.getElementById("guessText").innerHTML = "Did not match!"
    }
}

//Exercise 5
var oneDay = 24 * 60 * 60 * 1000; // hours*minutes*seconds*milliseconds
var currentDate = new Date();
var christmas = new Date(currentDate.getFullYear(), 11, 24);

var daysUntil = Math.round(
    Math.abs(
        (currentDate.getTime() - christmas.getTime()) / (oneDay)
    )
);

document.getElementById("daysUntilText").innerHTML = daysUntil;

//Exercise 6
function reverse(text) {
    document.getElementById("reverseText").innerHTML = text.split("").reverse().join("");
}

//Exercise 7
function cutWord(word) {
    var wordParts = [];
    var j = 0;
    for (var i = 1; i <= word.length; i++) {
        wordParts.push(word.slice(j, i));

        if (word.length == i) {
            j++;
            i = j;
        }
        
        if (word.length == j) {
            i = word.length;
        }
        
    }
    document.getElementById("wordParts").innerHTML = wordParts;
}

//Exercise 8 (No inline JS in HTML)
var button = document.getElementById("button");

button.onclick = function () {
    var alphaWord = document.getElementById("alphaWord").value;

    var alphaArray = alphaWord.split("");
    alphaArray.sort();

    document.getElementById("alphaText").innerHTML = alphaArray.join('');
}

//Exercise 9

var button2 = document.getElementById("button2");

button2.onclick = function () {
    var sentence = document.getElementById("sentence").value;

    var lengthArray = sentence.split(" ");
    var wordArray = sentence.split(" ");

    for (var i = 0; i < wordArray.length; i++) {
        var char = wordArray[i].substring(0, 1).toUpperCase();
        wordArray[i] = char + wordArray[i].substring(1);
    }

    lengthArray.sort(function (a, b) { return b.length - a.length });

    document.getElementById("sentenceText").innerHTML = wordArray.join(" ") + " - the longest word is " + lengthArray[0];
}

//Exercise 10
var button3 = document.getElementById("button3");

button3.onclick = function () {
    var prime = document.getElementById("prime").value;

    if (isPrime(prime)) {
        document.getElementById("primeText").innerHTML = "Prime number";
    }
    else {
        document.getElementById("primeText").innerHTML = "Not prime";
    }
}

function isPrime(num) {

    if (num < 2) return false;

    for (var i = 2; i < num; i++) {
        if (num % i == 0) {
            return false
        }
    }
    return true
}

//Exercise 11
var button4 = document.getElementById("button4");

button4.onclick = function () {
    var input = document.getElementById("type").value;

    console.log(whatTypeIs(input));
    document.getElementById("typeText").innerHTML = whatTypeIs(input);
}

function whatTypeIs(input) {
    if (input.match(/^\d+$/g)) {
        return typeof Number(input);
    }

    if (input.match(/^(false)?(true)?$/g)) {
        return typeof Boolean(input);
    }

    if (input.match(/^[\[\d+\,\]]+/g)) {
        return typeof Object(input);
    }

    return typeof String(input);
}

//Exercise 12
var text = "";

for (var i = 0; i <= 15; i++) {
    if (i % 2 == 0) {
        text += i + " is even <br />"
    }
    else {
        text += i + " is odd <br />"
    }
}

document.getElementById("evenOddText").innerHTML = text;

//Exercise 13
function happyCheck(n) {
    var newNum = n
        .toString()
        .split('')
        .reduce(function (sum, digit) {
            return sum + (+digit * +digit);
        }, 0);

    //Some unhappy number loop around
    if (newNum === 58 || newNum === 4 || newNum == 37) {
        return false;
    }

    if (newNum === 1) {
        return true;
    }
    else {
        return happyCheck(newNum);
    }
    
    
}


for (var i = 1; i < 50; i++) {
    if (happyCheck(i)) {
        document.getElementById("happyText").innerHTML += i + " is a Happy Number <br />"
    }
}

//Exercise 14
var workDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
document.getElementById("arrayText").innerHTML = 
    workDays.forEach(function (item, index) {
        if (item == "Thursday") {
            return item + " and "
        }
        else if (item == "Friday") {
            return item + " are workdays."
        }
        return item + ", "

    })