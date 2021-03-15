﻿using System;
using System.Runtime.InteropServices;

namespace LightningDB.Native
{
    public class Lmdb2 : ILmdb
    {
        public MDBResultCode mdb_env_create(out IntPtr env)
        {
            return LmdbMethods2.mdb_env_create(out env);
        }

        public void mdb_env_close(IntPtr env)
        {
            LmdbMethods2.mdb_env_close(env);
        }

        public MDBResultCode mdb_env_open(IntPtr env, string path, EnvironmentOpenFlags flags, UnixAccessMode mode)
        {
            return LmdbMethods2.mdb_env_open(env, path, flags, mode);
        }

        public MDBResultCode mdb_env_set_mapsize(IntPtr env, long size)
        {
            return LmdbMethods2.mdb_env_set_mapsize(env, new IntPtr(size));
        }

        public MDBResultCode mdb_env_get_maxreaders(IntPtr env, out uint readers)
        {
            return LmdbMethods2.mdb_env_get_maxreaders(env, out readers);
        }

        public MDBResultCode mdb_env_set_maxreaders(IntPtr env, uint readers)
        {
            return LmdbMethods2.mdb_env_set_maxreaders(env, readers);
        }

        public MDBResultCode mdb_env_set_maxdbs(IntPtr env, uint dbs)
        {
            return LmdbMethods2.mdb_env_set_maxdbs(env, dbs);
        }

        public MDBResultCode mdb_dbi_open(IntPtr txn, string name, DatabaseOpenFlags flags, out uint db)
        {
            return LmdbMethods2.mdb_dbi_open(txn, name, flags, out db);
        }

        public void mdb_dbi_close(IntPtr env, uint dbi)
        {
            LmdbMethods2.mdb_dbi_close(env, dbi);
        }

        public MDBResultCode mdb_drop(IntPtr txn, uint dbi, bool del)
        {
            return LmdbMethods2.mdb_drop(txn, dbi, del);
        }

        public MDBResultCode mdb_txn_begin(IntPtr env, IntPtr parent, TransactionBeginFlags flags, out IntPtr txn)
        {
            return LmdbMethods2.mdb_txn_begin(env, parent, flags, out txn);
        }

        public MDBResultCode mdb_txn_commit(IntPtr txn)
        {
            return LmdbMethods2.mdb_txn_commit(txn);
        }

        public void mdb_txn_abort(IntPtr txn)
        {
            LmdbMethods2.mdb_txn_abort(txn);
        }

        public void mdb_txn_reset(IntPtr txn)
        {
            LmdbMethods2.mdb_txn_reset(txn);
        }

        public MDBResultCode mdb_txn_renew(IntPtr txn)
        {
            return LmdbMethods2.mdb_txn_renew(txn);
        }

        public IntPtr mdb_version(out int major, out int minor, out int patch)
        {
            return LmdbMethods2.mdb_version(out major, out minor, out patch);
        }

        public MDBResultCode mdb_stat(IntPtr txn, uint dbi, out MDBStat stat)
        {
            return LmdbMethods2.mdb_stat(txn, dbi, out stat);
        }

        public MDBResultCode mdb_env_copy(IntPtr env, string path)
        {
            return LmdbMethods2.mdb_env_copy(env, path);
        }

        public MDBResultCode mdb_env_copy2(IntPtr env, string path, EnvironmentCopyFlags copyFlags)
        {
            return LmdbMethods2.mdb_env_copy2(env, path, copyFlags);
        }

        public MDBResultCode mdb_env_info(IntPtr env, out MDBEnvInfo stat)
        {
            return LmdbMethods2.mdb_env_info(env, out stat);
        }

        public MDBResultCode mdb_env_stat(IntPtr env, out MDBStat stat)
        {
            return LmdbMethods2.mdb_env_stat(env, out stat);
        }

        public MDBResultCode mdb_env_sync(IntPtr env, bool force)
        {
            return LmdbMethods2.mdb_env_sync(env, force);
        }

        public MDBResultCode mdb_get(IntPtr txn, uint dbi, ref MDBValue key, out MDBValue value)
        {
            return LmdbMethods2.mdb_get(txn, dbi, ref key, out value);
        }

        public MDBResultCode mdb_put(IntPtr txn, uint dbi, MDBValue key, MDBValue value, PutOptions flags)
        {
            return LmdbMethods2.mdb_put(txn, dbi, ref key, ref value, flags);
        }

        public MDBResultCode mdb_del(IntPtr txn, uint dbi, MDBValue key, MDBValue value)
        {
            return LmdbMethods2.mdb_del(txn, dbi, ref key, ref value);
        }

        public MDBResultCode mdb_del(IntPtr txn, uint dbi, MDBValue key)
        {
            return LmdbMethods2.mdb_del(txn, dbi, ref key, IntPtr.Zero);
        }

        public MDBResultCode mdb_cursor_open(IntPtr txn, uint dbi, out IntPtr cursor)
        {
            return LmdbMethods2.mdb_cursor_open(txn, dbi, out cursor);
        }

        public void mdb_cursor_close(IntPtr cursor)
        {
            LmdbMethods2.mdb_cursor_close(cursor);
        }

        public MDBResultCode mdb_cursor_renew(IntPtr txn, IntPtr cursor)
        {
            return LmdbMethods2.mdb_cursor_renew(txn, cursor);
        }

        public MDBResultCode mdb_cursor_get(IntPtr cursor, ref MDBValue key, ref MDBValue value, CursorOperation op)
        {
            return LmdbMethods2.mdb_cursor_get(cursor, ref key, ref value, op);
        }

        public MDBResultCode mdb_cursor_put(IntPtr cursor, MDBValue key, MDBValue value, CursorPutOptions flags)
        {
            return LmdbMethods2.mdb_cursor_put(cursor, ref key, ref value, flags);
        }

        /// <summary>
        /// store multiple contiguous data elements in a single request.
        /// May only be used with MDB_DUPFIXED.
        /// </summary>
        /// <param name="data">This span must be pinned or stackalloc memory</param>
        public MDBResultCode mdb_cursor_put(IntPtr cursor, ref MDBValue key, ref Span<MDBValue> data, CursorPutOptions flags)
        {
            ref var dataRef = ref MemoryMarshal.GetReference(data);
            return LmdbMethods2.mdb_cursor_put(cursor, ref key, ref dataRef, flags);
        }

        public MDBResultCode mdb_cursor_del(IntPtr cursor, CursorDeleteOption flags)
        {
            return LmdbMethods2.mdb_cursor_del(cursor, flags);
        }

        public MDBResultCode mdb_set_compare(IntPtr txn, uint dbi, CompareFunction cmp)
        {
            return LmdbMethods2.mdb_set_compare(txn, dbi, cmp);
        }

        public MDBResultCode mdb_set_dupsort(IntPtr txn, uint dbi, CompareFunction cmp)
        {
            return LmdbMethods2.mdb_set_dupsort(txn, dbi, cmp);
        }
    }
}
