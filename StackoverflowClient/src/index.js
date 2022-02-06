import React from 'react';
import ReactDOM from 'react-dom';
import {BrowserRouter, Route, Routes} from "react-router-dom"
import './index.css';
import Answers from './Answers';
import PageHeader from "./PageHeader"
import About from "./About"
import Questions from "./Questions"


ReactDOM.render(
    <BrowserRouter>
    <PageHeader />
      <Routes>
        <Route path="/" element={<Questions />}  />
        <Route path="/answer/undefined" element={<Questions />}  />
        <Route path="/answer/:id" element={<Answers />} />
        <Route path="/about" element={<About />}  />
      </Routes>
    </BrowserRouter>,
  document.getElementById('root')
);
 