import { ActionCreators } from "../redux/notesReducer";
import * as axios from 'axios'

const axiosInstance = axios.create({
    baseURL: 'https://localhost:5001/notes'
})

export const GetNotes = async (dispatch) => {
    try {
        const { data } = await axiosInstance.get();
        dispatch(ActionCreators.setNotes(data))
    }
    catch {
        console.log("Getting notes error ....")
    }
}

export const DeleteNote = async (dispatch, note) => {
    try {
        await axiosInstance.delete(`/${note.id}`)
        dispatch(ActionCreators.deleteNote(note))
    }
    catch {
        console.log("Removing note error ....")
    }
}

export const NewNote = async (dispatch, note) => {
    try {
        const { data } = await axiosInstance.post('', note);
        dispatch(ActionCreators.newNote(data));
    }
    catch {
        console.log("Creating new note error ....")
    }
}

export const EditNote = async (dispatch, note) => {
    try {
        const { data } = await axiosInstance.put('', note);
        dispatch(ActionCreators.editNote(data))
    }
    catch {
        console.log("Editing note error ....")
    }
}


export const ChangeStatus = async (dispatch, note) => {
    try {
        var noteToSend = {
            ...note, status: 1 - note.status
        }
        const { data } = await axiosInstance.put('', noteToSend);
        dispatch(ActionCreators.editNote(data))
    }
    catch (exception) {
        console.log("Change status note error ....")
    }
}