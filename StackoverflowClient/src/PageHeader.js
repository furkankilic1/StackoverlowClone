import React from 'react'
import { Link, useLocation } from "react-router-dom"
const PageHeader = ({ title }) => {
    const loc = useLocation();

    return (
        <div className="pageHeader">

            <a class="navbar-brand" href="/">
                <img src="https://upload.wikimedia.org/wikipedia/commons/e/ef/Stack_Overflow_icon.svg" alt="" width="30" height="24" class="d-inline-block align-text-top" />
                stack<span className="pageHeaderSpan">overflow</span> clone
            </a>
            <ul>
                <li>
                    {
                        loc.pathname === "/" ?
                            <span style={disableLink}>Questions</span>
                            :
                            <Link to="/">Questions</Link>
                    }

                </li>
                <li>
                    {
                        loc.pathname === "/about" ?
                            <span style={disableLink}>About</span>
                            :
                            <Link to="/about">About</Link>
                    }
                </li>
            </ul>
        </div>
    )
}

const disableLink = {
    color: "#999"
}

export default PageHeader
