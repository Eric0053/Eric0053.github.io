const startBtn = document.querySelector("#start_btn")
const showAnsBtn = document.querySelector("#show_answer_btn")
const restartBtn = document.querySelector("#restart_btn")
const guessHistoryList = document.querySelector("#guess_history_list")
const guessInput = document.querySelector('#guess_input')
const guessBtn = document.querySelector('#guess_btn')
const gameMsgToast = document.querySelector('#game_msg_toast')
let answer;
const moalBoot = new bootstrap.Modal(document.querySelector
('#end_game_modal'))
const endgamebtn = document.querySelector('#end_game_btn')

function initGame() {
    answer = gernerAns();

    guessHistoryList.innerHTML = "";
}

function gernerAns() {
    const numArr = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];
    numArr.sort((a, b) => getRandomArbitrary(-1, 1));

    return numArr.slice(0, 4).join("");//???
}

function getRandomArbitrary(min, max) {
    return Math.random() * (max - min) + min;
}

startBtn.addEventListener("click", initGame)

restartBtn.addEventListener("click", initGame)
showAnsBtn.addEventListener("click", () => {
    // return gernerAns()
    console.log(`answer ${answer}`)
});

guessBtn.addEventListener("click", () => {
    const val = guessInput.value.trim();
    console.log(val)

    if (val === "" || isNaN(val)) {
        showHint("請輸入合法的數字")
        // alert("請輸入合法的數字")
        guessInput.value = ""
        return;
    }
    if( val.length > 4 || new Set(val).size !==4 ){
        showHint("請確認輸入數字的數量")
        guessInput.value = "";
        return
    }
    
    let a = 0,b = 0;
    for (let i = 0; i < answer.length; i++) {
        if (val[i] === answer[i]) {
            a++
        } else if (answer.includes(val[i])) {
            b++
        }
    }
        if (a === 4) {
            // alert("通過")
            moalBoot.show("通過")
        }

        guessInput.value = ""
        appendHistory(a, b, val)
    }
);



function appendHistory(a, b, input) {
    const li = document.createElement("li")
    li.classList.add("list-group-item")
    const span = document.createElement("span")
    const badgecolor = a === 4 ? "bg-success" : "bg-danger";
    span.classList.add("badge", badgecolor)
    span.textContent = `${a}A ${b}B`
    li.append(span, input)
    guessHistoryList.append(li);
}
function showHint(msg) {
    gameMsgToast.querySelector(".toast-body").textContent = msg;
    const myToast = bootstrap.Toast.getOrCreateInstance(gameMsgToast)
    myToast.show()

    // document.getElementById('myToastEl') 
    // const myToast = bootstrap.Toast.getOrCreateInstance(myToastEl)
}

endgamebtn.addEventListener("click",()=>{
    moalBoot.hide();
})