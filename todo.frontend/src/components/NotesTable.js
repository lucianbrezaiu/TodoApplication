import React, { useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { DeleteNote, GetNotes, ChangeStatus } from '../services/notes';
import { Button } from 'react-bootstrap';
import { EditNoteModal } from './NoteModal';
import Checkbox from 'react-checkbox-component';

export const NotesTable = () => {
    const notes = useSelector(state => state.notesReducer.notes);
    const dispatch = useDispatch();

    useEffect(() => {
        GetNotes(dispatch);
    }, []);

    return <table className='table table-hover table-success table-striped'>
        <thead className='thead-dark'>
            <tr>
                <th>Title</th>
                <th>Description</th>
                <th>Created date</th>
                <th>Actions</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            {
                notes.map(note =>
                    <tr key={note.id}>
                        <td style={{ textAlign: 'center' }}><h2>{note.title}</h2></td>
                        <td style={{ textAlign: 'center' }}>{note.description}</td>
                        <td style={{ textAlign: 'center' }}>{note.createdAt}</td>
                        <td style={{ width: '15rem' }}>
                            <div style={{ display: 'inline-block', marginRight: '3px' }}>
                                <EditNoteModal note={note} />
                            </div>
                            <div style={{ display: 'inline-block', marginLeft: '3px' }}>
                                <Button className='btn btn-danger' onClick={() => DeleteNote(dispatch, note)}>Delete</Button>
                            </div>
                        </td>
                        <td style={{ textAlign: 'center' }}>
                            <label>
                                <Checkbox
                                    shape="square"
                                    isChecked={note.status === 0 ? false : true}
                                    onChange={() => ChangeStatus(dispatch, note)}
                                />
                            </label>
                        </td>
                    </tr>
                )
            }
        </tbody>
    </table>
}
