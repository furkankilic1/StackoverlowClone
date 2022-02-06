import React, { useState, useEffect } from 'react'
import { useParams } from "react-router-dom"

const Answers = () => {
    const [list, setList] = useState([]);
    const [name, setName] = useState("");
    const [loading, setLoading] = useState(true);
    const params = useParams();

    useEffect(() => {
        setLoading(true)
        const getAnswers = async () => {
            const answersData = await fetch(`https://localhost:44396/Stackoverflow/getAnswersForQuestion?questionId=${params.id}`)
            const answerJson = await answersData.json();

            return answerJson.answers;
        }
        getAnswers().then((answer) => {
            setLoading(false)
            setList(answer);
        })

        const getQuestion = async () => {
            const questionData = await fetch(`https://localhost:44396/Stackoverflow/getQuestion?questionId=${params.id}`)
            const questionJson = await questionData.json();

            return questionJson.question;
        }
        getQuestion().then((question) => {
            setLoading(false)
            setName(question.questionContent);
        })

    }, [params.id]);

    return (
        <div>
            {
                loading ?
                    <div className="spinner">
                        <img src="/spinner.gif" alt="" />
                    </div>
                    :
                    <div className="answers">
                        <div className="header">
                            <h2 style={{ color: "black" }}>{name}</h2>
                        </div>

                        <ul>
                            {
                                list.length === 0 ?
                                    <h4>This question has no answer yet. You can be the first!</h4>
                                    :
                                    list.map((item, i) =>
                                        <li key={i}>
                                            <span>{item.answerContent}</span>
                                        </li>
                                    )
                            }
                        </ul>

                        <form onSubmit={e => {
                            e.preventDefault();

                            setList([...list, { answerContent: e.target.newAnswer.value }]);

                            const addAnswer = async () => {
                                await fetch(`https://localhost:44396/Stackoverflow/post_AddAnswer?questionId=${params.id}&answerContent=${e.target.newAnswer.value}`, {
                                    method: "POST",
                                    headers: {
                                        "Content-Type": "application/json"
                                    },
                                });
                            }
                            addAnswer();
                            e.target.newAnswer.value = "";

                        }} className="addForm">
                            <input type="text" name="newAnswer" />
                            <button>Add Answer</button>
                        </form>

                    </div>
            }
        </div>
    )
}
export default Answers

