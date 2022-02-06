import React, { useEffect, useState } from 'react'
import { Link } from "react-router-dom"

const Questions = () => {
    const [list, setList] = useState([]);
    const [search, setSearch] = useState("");
    const [error, setError] = useState(null);


    useEffect(() => {
        //console.log("List mounted")
        const getQuestions = async () => {
            const data = await fetch("https://localhost:44396/Stackoverflow/getAllQuestions");
            const list = await data.json();

            return list.questions;
        }
        getQuestions().then((list) => {
            setList(list);
        }).catch(() => {
            setError("REST-Server is down")
        });

    }, [])
    return (
        <div className="questions">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
                <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z" />
            </svg>
            <input type="text" name="search" value={search}
                onChange={(e) => setSearch(e.target.value)}
                placeholder="search" className="searchInput"
            />
            <ul>
                {
                    list.filter(p => p.questionContent.toLowerCase().includes(search.toLowerCase())).map((item, i) =>
                        <li key={i}>
                            <Link to={`/answer/${item.questionId}`}>{item.questionContent}</Link>
                        </li>
                    )
                }
            </ul>
            <form onSubmit={e => {
                e.preventDefault();

                setList([...list, { questionContent: e.target.newQuestion.value }]);

                const addQuestion = async () => {
                    await fetch(`https://localhost:44396/Stackoverflow/post_AddQuestion?questionContent=${e.target.newQuestion.value}`, {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json"
                        },
                    });
                }
                addQuestion();
                
                e.target.newQuestion.value = "";

            }} className="addForm">
                <input type="text" name="newQuestion" />
                <button>Add Question</button>
            </form>

            {
                error ? <p>{error}</p> : ""
            }
        </div>
    )
}

export default Questions
