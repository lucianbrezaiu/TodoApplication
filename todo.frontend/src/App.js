import React from 'react';
import './App.css';
import { NewNoteModal } from './components/NoteModal';
import { NotesTable } from './components/NotesTable'

const App = () => {
  return (
    <div className="App">
      <br />
      <h3 >Todo list</h3>
      <br />

      <div style={{ maxWidth: '100%', margin: 'auto' }}>
        <NotesTable />
        <div style={{ textAlign: 'center' }}>
          <NewNoteModal />
        </div>
      </div>
    </div>
  );
}

export default App;
